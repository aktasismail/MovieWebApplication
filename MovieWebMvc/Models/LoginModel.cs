namespace MovieWebMvc.Models
{
    public class LoginModel
    {
        private string _returnurl;
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ReturnUrl 
        { 
            get {
                if (_returnurl is null)
                    return "/";
                else
                    return _returnurl;
                }
            set {
                _returnurl = value; 
                } 
        }
    }
}
