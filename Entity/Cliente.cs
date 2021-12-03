<<<<<<< HEAD
using System;

namespace Back_end
{
    public class Cliente
    {
        public int id {get; set;}
        public string nome {get; set;}
        public string cpf {get; set;}
        public DateTime dataNascimento {get; set;}
        public string email {get; set;}
        public string senha {get; set;}
        public string perfil {get;  set;}
        public string rua {get;  set;}
        public string numero {get;  set;}
        public string complemento {get;  set;}
        public string cidade {get;  set;}
        public int cep {get;  set;}

    }
}
=======
namespace Back_end.Entity
{
    public class Cliente{
    public int id {get; set;} 
    public string nome {get; set;}
    public string cpf {get; set;}
    public date dataNascimento {get; set;}
    public string email {get; set;}
    public string senha {get; set;}
    public string perfil {get; set;}
    public string endereco_rua {get; set;}
    public string endereco_numero {get; set;}
    public string endereco_complemento {get; set;}
    public string endereco_bairro {get; set;}
    public string endereco_cidade {get; set;}
    public int endereco_cep {get; set;}

    }
}
>>>>>>> cbffc80931c3d623a4b914fdd8e582f4d1ad1e3c
