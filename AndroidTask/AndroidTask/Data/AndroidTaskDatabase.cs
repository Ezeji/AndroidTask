using AndroidTask.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndroidTask.Data
{
    public class AndroidTaskDatabase
    {
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        });

        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;

        public AndroidTaskDatabase()
        {
            InitializeAsync().SafeFireAndForget(false);
        }


        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(RegisterUser).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(RegisterUser)).ConfigureAwait(false);
                    initialized = true;
                }
            }
        }


        public async Task<string> LoginUser(LoginUser loginUser)
        {
            var encryptedPassword = PasswordEncryption.HashPassword(loginUser.Password.ToString());

            var registeredUser = await Database.Table<RegisterUser>()
                                               .Where(user => user.Email == loginUser.Email && user.EncryptedPassword == encryptedPassword)
                                               .FirstOrDefaultAsync();

            if (registeredUser == null)
            {
                return "There's no such user...";
            }
            else
            {
                return "User exists...";
            }
        }

        public async Task<string> SignupUser(RegisterUser registerUser)
        {
            await Database.InsertAsync(registerUser);

            return "Data saved...";
        }

    }
}
