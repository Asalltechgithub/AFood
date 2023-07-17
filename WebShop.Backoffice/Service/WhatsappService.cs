namespace WebShop.Backoffice.Service
{
    public class WhatsappService
    {

        private void EnviarWhatsapp()
        {
            string Telefone = "5521982676984";
            string msg = "Seu pedido esta a caminho ";
            string Data = DateTime.Now.ToString();

            var txt = $"https://api.whatsapp.com/send?phone={Telefone}&text={msg} para o dia {Data}";
           
        }
    }
}
