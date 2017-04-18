using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Willians.LojaVirtual.Dominio.Entidade
{
    public class EmailPedido
    {
        private readonly EmailConfiguracoes _emailConfiguracoes;

        public EmailPedido(EmailConfiguracoes emailConfig)
        {
            _emailConfiguracoes = emailConfig;
        }

        public void ProcessarPedido(Carrinho carrinho, Pedido pedido)
        {
            var smtp = new SmtpClient();

            smtp.Credentials = new System.Net.NetworkCredential(_emailConfiguracoes.Usuario, _emailConfiguracoes.Senha);

            smtp.EnableSsl = _emailConfiguracoes.UsarSsl;
            smtp.Host = _emailConfiguracoes.ServidorSmtp;
            smtp.Port = _emailConfiguracoes.ServidorPorta;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(_emailConfiguracoes.Usuario, _emailConfiguracoes.Senha);

            if (_emailConfiguracoes.EscreverArquivo) {
                smtp.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                smtp.PickupDirectoryLocation = _emailConfiguracoes.PastaArquivos;
                smtp.EnableSsl = false;
            }

            StringBuilder body = new StringBuilder();
            body.AppendLine("Novo Pedido:");
            body.AppendLine(new string('-',10));
            body.AppendLine("Itens......:");

            foreach (var itens in carrinho.ItensDoCarrinho()) {
                decimal subTotal = itens.Quantidade * itens.Produto.Preco;

                body.AppendFormat("{0} x {1} = SubTotal {2:c} \n", itens.Quantidade, itens.Produto.Preco, subTotal); 
            }

            body.AppendFormat("Valor Total do Pedido: {0:c} \n", carrinho.ObterValorTotal());

            body.AppendLine(new string('-', 10));
            body.AppendLine("Enviar para: ");
            body.AppendLine(pedido.NomeCliente ?? "");
            body.AppendLine(pedido.Email ?? "");
            body.AppendLine(pedido.Endereco ?? "");
            body.AppendLine(pedido.Cidade ?? "");
            body.AppendLine(pedido.Complemento ?? "");
            body.AppendLine(new string('-', 10));
            body.AppendFormat("Para Presente: {0}", (pedido.EmbrulhaPresente ? "Sim" : "Não"));

            MailMessage mail = new MailMessage(from: _emailConfiguracoes.De,
                                               to: _emailConfiguracoes.Para,
                                               subject: "Novo Pedido",
                                               body: body.ToString());

            if (_emailConfiguracoes.EscreverArquivo) {
                mail.BodyEncoding = Encoding.GetEncoding("ISO-8859-1");
            }

           smtp.Send(mail);
        }
    }
}
