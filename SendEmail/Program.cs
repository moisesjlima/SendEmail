using System;
using System.Net.Mail;
using System.Net.Mime;

namespace SendEmail
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Instanciando a Classe de SMTP e configurando os atributos necessários
                SmtpClient client = new SmtpClient("smtp.office365.com"); //*é possivel passar o número da porta como segundo parametro no construtor ("smtp.office365.com", 587)

                client.Port = 587; //A Porta referente a seu servidor SMTP
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false; //Necessario deixar false para especificar suas credenciais
                System.Net.NetworkCredential credential = new System.Net.NetworkCredential("seuEmail", "suaSenha*"); //Criando a variavel para passar suas credenciais
                client.EnableSsl = true; //Habilitando Secure Socket Layer, segurando que os dados trafegados estaram protegidos(Criptografados)
                client.Credentials = credential;

                //Instanciando a Classe de mensagem do email
                MailMessage message = new MailMessage("emailDeEnvio", "emailDeDestino");
                message.Subject = "Teste de envio de email"; //Titulo do email
                message.Body = "<p>Enviado automaticamente!<p>"; //
                message.IsBodyHtml = true;
                String file = "Caminho do arquivo a ser anexado"; 
                Attachment fileEmail = new Attachment(file, MediaTypeNames.Application.Octet);
                message.Attachments.Add(fileEmail);
                client.Send(message); //Fazendo o envio do email passando a variavel instanciada da Clasee MailMessage


                Console.WriteLine("Success!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}