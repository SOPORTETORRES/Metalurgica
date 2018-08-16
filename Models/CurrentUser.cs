
namespace Metalurgica
{
    public class CurrentUser
    {
        private string _login = "";
        private string _name = "";
        private string _IdUser = "";
        private int _machine = -1;
        private string _computerName = "";
        private string _DescripcionTotem = "";
        private string _DescripcionMaq = "";
        private string _PerfilUsuario = "";
        private int  _IdMaquina = -1;
        private int _IdTotem = -1;
        private int _IdAccesoTotem = -1;

        public string Login
        {
            get { return _login; }
            set { _login = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
       
        public int Machine
        {
            get { return _machine; }
            set { _machine = value; }
        }
        
        public string ComputerName
        {
            get { return _computerName; }
            set { _computerName = value; }
        }
        public string Iduser
        {
            get { return _IdUser; }
            set { _IdUser = value; }
        }

        public string DescripcionTotem
        {
            get { return _DescripcionTotem; }
            set { _DescripcionTotem = value; }
        }

        public string DescripcionMaq
        {
            get { return _DescripcionMaq; }
            set { _DescripcionMaq = value; }
        }

        public string PerfilUsuario
        {
            get { return _PerfilUsuario; }
            set { _PerfilUsuario = value; }
        }
        
        public int IdMaquina
        {
            get { return _IdMaquina; }
            set { _IdMaquina = value; }
        }


        public int IdTotem
        {
            get { return _IdTotem; }
            set { _IdTotem = value; }
        }
        //
        public int IdAccesoTotem
        {
            get { return _IdTotem; }
            set { _IdTotem = value; }
        }
    }
}