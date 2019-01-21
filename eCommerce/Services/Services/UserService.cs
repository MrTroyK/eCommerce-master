using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using eCommerce.Repositories.Interfaces;
using Model.Model;
using Repositories.Interfaces;

public class UserService : IUserService
{

    private new IUserRepository _userRepository;


    public UserService(IUserRepository repository)
    {
        _userRepository = repository;
    }

    public async Task<bool> Authenticate(string mail, string password)
    {
        var user = await Task.Run(() => _userRepository.CheckExist(mail, encrypt(password)));
        return user;
    }

    public User Create(User user)
    {
        user.Password = encrypt(user.Password);
        return _userRepository.Add(user);
    }

    public bool Delete(User user)
    {
        return _userRepository.Delete(user.Id);
    }

    private string encrypt(string word)
    {
        if (word == null)
        {
            word = string.Empty;
        }

        var passwordBytes = Encoding.UTF8.GetBytes(word);
        passwordBytes = SHA256.Create().ComputeHash(passwordBytes);
        return Convert.ToBase64String(passwordBytes);
    }
}

//    private String decrypt(String word)
//    {

//    if (word == null)
//    {
//        word = String.Empty;
//    }

//    var passwordBytes = Convert.FromBase64String(word);

//    passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

//    var bytesDecrypted = Cipher.Decrypt(bytesToBeDecrypted, passwordBytes);

//    return Encoding.UTF8.GetString(bytesDecrypted);

//}

