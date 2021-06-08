using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Extensions.Options;
using Seuphone.Api.Data;
using Seuphone.Api.Helpers;
using Seuphone.Api.Models;
using System.IO;

namespace Seuphone.Api.Services
{
    public class OrderService
    {
        private SeuphoneApiContext _context;
        private readonly AppSettings _appSettings;


        public OrderService(IOptions<AppSettings> appSettings, SeuphoneApiContext context)
        {
            _appSettings = appSettings.Value;
            _context = context;
        }

        public Stream CreateOrderPDF(Order order)
        {
            using (var document = new Document(PageSize.A4, 30, 30, 15, 15))
            {
                var output = new MemoryStream();

                var writer = PdfWriter.GetInstance(document, output);

                writer.CloseStream = false;

                document.Open();



                Font titleFont = new Font(Font.FontFamily.HELVETICA, 16, Font.BOLD);
                Font regularFont = new Font(Font.FontFamily.HELVETICA, 12, Font.NORMAL);
                Font boldFont = new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD);

                Paragraph title = new Paragraph("Contrato Seuphone", titleFont);
                title.Alignment = Element.ALIGN_CENTER;
                document.Add(title);
                document.Add(new Chunk("\r\n"));

                var p1Text = @"Leia atentamente antes de usar este site: Os seguintes termos de serviço('Termos de Serviço') regem o uso do site SeuPhone(o 'Site') e o SeuPhone baseado na web, integração de aplicativos e dados serviço de ligação acessado através do Site('Serviço'), ambos os quais são operado pela SeuPhone LTD. ('SeuPhone').
Usando o Site e / ou o Serviço, você concorda irrevogavelmente que tal uso está sujeito a estes Termos de Serviço. 
Se você não concordar com estes Termos de Serviço, você não pode usar o Site ou o Serviço.Se você estiver celebrando estes Termos de Serviço em nome de uma entidade, você declara que tem autoridade real para vincular tal entidade a estes Termos de Serviço.
SeuPhone reserva expressamente o direito de modificar os Termos de Serviço a qualquer momento em seu próprio discrição, e sem aviso prévio, incluindo tal alteração e / ou modificação nestes Termos de Serviço, juntamente com um aviso do data efetiva de tais Termos de Serviço modificados.
Qualquer uso continuado por você do Site ou do Serviço após a publicação de tais Termos modificados de O serviço deve ser considerado como uma indicação de seu acordo irrevogável com tal Termos de Serviço modificados. 
Assim, se em algum momento você não concordar com estar sujeito a quaisquer Termos de Serviço modificados, você não pode mais usar o Site ou serviço.";


                Paragraph p1 = new Paragraph(p1Text, regularFont);
                p1.Alignment = Element.ALIGN_JUSTIFIED;
                document.Add(p1);


                var p2Title = @"1. Serviço Oferecido";
                var p2Text = @"SeuPhone é um provedor de serviços técnicos na área de aplicação rápida desenvolvimento na Internet. 
Para este efeito, SeuPhone desenvolveu um Serviço, que pode ser acessado por você na Internet para iniciar a construção Aplicativos da web. 
A funcionalidade importante do Serviço é criar aplicativo combinando serviços do Site e APIs de terceiros. 
The SeuPhone site, o software e a documentação serão consultados coletivamente como a plataforma SeuPhone.";

                Paragraph pT2 = new Paragraph(p2Title, boldFont);
                Paragraph p2 = new Paragraph(p2Text, regularFont);
                p2.Alignment = Element.ALIGN_JUSTIFIED;

                document.Add(pT2);
                document.Add(p2);


                var p3Title = @"2. Contas de Usuário, Senhas e Taxas";
                var p3Text = @"
(a) Registro da conta e licença de uso: Para acessar e usar todos dos recursos do Serviço, você deve abrir uma conta ('Usuário Conta') registrando-se no SeuPhone. Quando você se registra para o seu usuário Conta você deve fornecer informações verdadeiras, precisas, atuais e completas ('Perfil de usuário'), e você concorda em atualizar as informações da conta para para garantir que seja atual. Mediante registro adequado e abertura de um Conta de usuário, e sujeito a todos os termos e condições destes Termos de Serviço, SeuPhone concede a você o pessoal, direito intransferível e licença para usar o Serviço, exclusivamente para você fins comerciais internos, até que você ou SeuPhone decidir rescindir tal direito de acordo com estes Termos e Condições 

(b) Elegibilidade: Como uma condição expressa de permissão para abrir um Usuário Conta, você representa e garante que (i) tem a capacidade legal (incluindo, sem limitação, ter idade suficiente) para entrar em contratos ao abrigo da lei da jurisdição em que reside.

(c) Senhas: Após o registro no Site, você fornecerá SeuPhone com uma senha para acessar sua conta. Você é responsável por mantendo a confidencialidade de sua senha e de todos os seus atividades e de terceiros que ocorram por meio de sua conta, seja ou não autorizado por você. Você concorda em notificar imediatamente o SeuPhone de qualquer uso não autorizado, suspeito ou real, de sua conta de usuário. Você concorda que SeuPhone não será, em nenhuma circunstância, responsável por qualquer custo, perda, danos ou despesas decorrentes de uma falha sua em mantenha a segurança de sua senha.";

                Paragraph pT3 = new Paragraph(p3Title, boldFont);
                Paragraph p3 = new Paragraph(p3Text, regularFont);
                p2.Alignment = Element.ALIGN_JUSTIFIED;

                document.Add(pT3);
                document.Add(p3);



                var p4Title = @"3. Site Content";
                var p4Text = @"(a) Conteúdo SeuPhone: Exceto quando indicado de outra forma, as informações, materiais (incluindo, sem limitação, HTML, texto, áudio, vídeo, branco papéis, comunicados de imprensa, folhas de dados, descrições de produtos, software e FAQs e outros conteúdos) disponíveis no Site e / ou no Serviço (coletivamente, 'SeuPhone Content') são obras protegidas por direitos autorais de SeuPhone e seus licenciadores, e SeuPhone e seus licenciados expressamente retêm todos título e interesse corretos no e para o Conteúdo SeuPhone, incluindo, sem limitação, todos os direitos de propriedade intelectual neles e nos mesmos. Exceto conforme expressamente permitido nestes Termos de Serviço, qualquer uso do O Conteúdo SeuPhone pode violar direitos autorais e / ou outras leis aplicáveis.
              
(b) Conteúdo de terceiros: Além do conteúdo do SeuPhone, o site e / ou o Serviço pode conter informações e materiais fornecidos ao SeuPhone por terceiros (coletivamente, 'Conteúdo de terceiros'). Conteúdo de terceiros é a obra protegida por direitos autorais de seu proprietário, que expressamente retém todos os direitos título e interesse no e para o Conteúdo de terceiros, incluindo, sem limitação, todos os direitos de propriedade intelectual neles e nos mesmos. No além de estar sujeito a estes Termos de Serviço, Conteúdo de Terceiros também podem estar sujeitos a termos de uso diferentes e / ou adicionais e / ou políticas de privacidade de tais terceiros. Entre em contato com o apropriado terceiros para obter mais informações sobre tais diferentes e / ou termos de uso adicionais aplicáveis ​​ao Conteúdo de Terceiros.
              
(c) Licença limitada de conteúdo do site: SeuPhone concede a você a licença limitada, direito revogável, intransferível e não exclusivo de uso do SeuPhone Conteúdo e conteúdo de terceiros (coletivamente, 'Conteúdo do site') por exibir o conteúdo do site em seu computador e fazer o download e imprimir páginas do Site contendo Conteúdo do Site, sob a condição de (i) tal atividade é exclusivamente para seu uso pessoal, educacional ou outro uso não comercial, (ii) você não modifica ou prepara trabalhos derivados de o Conteúdo do Site, (iii) você não obscurece, altera ou remove qualquer aviso de direitos autorais estabelecidos em quaisquer páginas do site ou conteúdo do site, (iv) você não de outra forma, reproduzir, redistribuir ou exibir publicamente qualquer parte do Site Conteúdo e (v) você não copia nenhum Conteúdo do Site para qualquer outra mídia ou outro formato de armazenamento";

                Paragraph pT4 = new Paragraph(p4Title, boldFont);
                Paragraph p4 = new Paragraph(p4Text, regularFont);
                p2.Alignment = Element.ALIGN_JUSTIFIED;

                document.Add(pT4);
                document.Add(p4);

                document.NewPage();


                Paragraph title2 = new Paragraph("Descrição do Contrato", titleFont);
                title2.Alignment = Element.ALIGN_CENTER;

                document.Add(title2);
                document.Add(new Chunk("\r\n"));

                Paragraph cliente = new Paragraph($"Cliente: {order.User.Name}");
                Paragraph email = new Paragraph($"E-mail: {order.User.Email}");
                Paragraph logradouro = new Paragraph($"Logradouro: {order.User.Address}");
                Paragraph criacao = new Paragraph($"Início Contrato: {order.CreationDate}");
                Paragraph duracao = new Paragraph($"Duração Contrato: {order.ContractDuration} ano(s)");

                document.Add(cliente);
                document.Add(email);
                document.Add(logradouro);
                document.Add(criacao);
                document.Add(duracao);

                document.Add(new Chunk("\r\n"));

                PdfPTable tabela = new PdfPTable(5);
                tabela.HorizontalAlignment = 1;
                tabela.WidthPercentage = 100;

                tabela.AddCell(new Phrase("ID", boldFont));
                tabela.AddCell(new Phrase("Descrição", boldFont));
                tabela.AddCell(new Phrase("Valor", boldFont));
                tabela.AddCell(new Phrase("Qtd.", boldFont));
                tabela.AddCell(new Phrase("Subtotal", boldFont));

                foreach (var item in order.OrderItems)
                {
                    tabela.AddCell(item.Id.ToString());
                    tabela.AddCell(item.Product.Description);
                    tabela.AddCell(item.Product.Price.ToString());
                    tabela.AddCell(item.Quantity.ToString());
                    tabela.AddCell(item.SubTotal.ToString());
                }

                PdfPCell total = new PdfPCell(new Phrase($"TOTAL: {order.Total}", boldFont));
                total.Colspan = 5;
                total.HorizontalAlignment = 2; // 0 = esquerda, 1 = centro, 2 = direita
                tabela.AddCell(total);
               
                document.Add(tabela);

                document.Close();

                output.Seek(0, SeekOrigin.Begin);

                return output;
            }
        }


        public Stream CreateOrderInvoicePDF(Order order)
        {
            using (var document = new Document(PageSize.A4, 30, 30, 15, 15))
            {
                var output = new MemoryStream();

                var writer = PdfWriter.GetInstance(document, output);

                writer.CloseStream = false;

                document.Open();



                Font titleFont = new Font(Font.FontFamily.HELVETICA, 16, Font.BOLD);
                Font regularFont = new Font(Font.FontFamily.HELVETICA, 12, Font.NORMAL);
                Font boldFont = new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD);

                Paragraph title = new Paragraph("Nota Fiscal", titleFont);
                title.Alignment = Element.ALIGN_CENTER;
                document.Add(title);
                document.Add(new Chunk("\r\n"));


                PdfPTable tabelaInicio = new PdfPTable(5);
                tabelaInicio.HorizontalAlignment = 1;
                tabelaInicio.WidthPercentage = 100;

                PdfPCell celula = new PdfPCell(new Phrase("Seuphone", boldFont));
                celula.Colspan = 2;
                celula.HorizontalAlignment = 1; // 0 = esquerda, 1 = centro, 2 = direita
                celula.Padding = 0f;
                celula.BorderWidth = 0f;
                celula.BorderWidthRight = 0.5f;
                celula.BorderWidthLeft = 0.5f;
                celula.BorderWidthTop = 0.5f;
                tabelaInicio.AddCell(celula);



                PdfPCell celulavazia = new PdfPCell(new Phrase(""));
                celulavazia.Colspan = 3;
                celulavazia.BorderWidth = 0f;
                celulavazia.BorderWidthRight = 0.5f;
                celulavazia.BorderWidthLeft = 0.5f;
                celulavazia.BorderWidthTop = 0.5f;
                tabelaInicio.AddCell(celulavazia);

                PdfPCell celulainfo = new PdfPCell(new Phrase("Nota Fiscal", boldFont));
                celulainfo.Colspan = 2;
                celulainfo.HorizontalAlignment = 1; // 0 = esquerda, 1 = centro, 2 = direita
                celulainfo.Padding = 2f;
                celulainfo.BorderWidth = 0f;
                celulainfo.BorderWidthRight = 0.5f;
                celulainfo.BorderWidthLeft = 0.5f;
                celulainfo.BorderWidthBottom = 0.5f;
                tabelaInicio.AddCell(celulainfo);


                PdfPCell celulatitulo = new PdfPCell(new Phrase("Informações da Nota Fiscal"));
                celulatitulo.Colspan = 3;
                celulatitulo.HorizontalAlignment = 1; // 0 = esquerda, 1 = centro, 2 = direita
                celulatitulo.Padding = 2f;
                celulatitulo.BorderWidth = 0f;
                celulatitulo.BorderWidthRight = 0.5f;
                celulatitulo.BorderWidthLeft = 0.5f;
                celulatitulo.BorderWidthBottom = 0.5f;
                tabelaInicio.AddCell(celulatitulo);


                PdfPCell celulanome = new PdfPCell();
                celulanome.AddElement(new Phrase($"Nome: {order.User.Name}", regularFont));
                celulanome.Colspan = 2;
                tabelaInicio.AddCell(celulanome);

                PdfPCell celulaemail = new PdfPCell();
                celulaemail.AddElement(new Phrase($"E-mail: {order.User.Email}", regularFont));
                celulaemail.Colspan = 3;
                tabelaInicio.AddCell(celulaemail);

                PdfPCell celulalogradouro = new PdfPCell();
                celulalogradouro.AddElement(new Phrase($"Logradouro: {order.User.Address}", regularFont));
                celulalogradouro.Colspan = 5;
                tabelaInicio.AddCell(celulalogradouro);

                PdfPCell celulainicio = new PdfPCell();
                celulainicio.AddElement(new Phrase($"Início Contrato: {order.CreationDate}", regularFont));
                celulainicio.Colspan = 5;
                tabelaInicio.AddCell(celulainicio);

                PdfPCell celulacontrato = new PdfPCell();
                celulacontrato.AddElement(new Phrase($"Duração Contrato: {order.ContractDuration} ano(s)", regularFont));
                celulacontrato.Colspan = 5;
                tabelaInicio.AddCell(celulacontrato);



                PdfPCell celulaitens = new PdfPCell(new Phrase("Itens", boldFont));
                celulaitens.Colspan = 5;
                celulaitens.HorizontalAlignment = 1; // 0 = esquerda, 1 = centro, 2 = direita
                celulaitens.BorderWidth = 0f;
                celulaitens.BorderWidthBottom = 0.5f;
                celulaitens.BorderWidthRight = 0.5f;
                celulaitens.BorderWidthLeft = 0.5f;
                tabelaInicio.AddCell(celulaitens);


                document.Add(tabelaInicio);



                PdfPTable tabela = new PdfPTable(5);
                tabela.HorizontalAlignment = 1;
                tabela.WidthPercentage = 100;

                tabela.AddCell(new Phrase("ID", boldFont));
                tabela.AddCell(new Phrase("Descrição", boldFont));
                tabela.AddCell(new Phrase("Valor", boldFont));
                tabela.AddCell(new Phrase("Qtd.", boldFont));
                tabela.AddCell(new Phrase("Subtotal", boldFont));

                foreach (var item in order.OrderItems)
                {
                    tabela.AddCell(item.Id.ToString());
                    tabela.AddCell(item.Product.Description);
                    tabela.AddCell(item.Product.Price.ToString());
                    tabela.AddCell(item.Quantity.ToString());
                    tabela.AddCell(item.SubTotal.ToString());
                }

                PdfPCell total = new PdfPCell(new Phrase($"TOTAL: {order.Total}", boldFont));
                total.Colspan = 5;
                total.HorizontalAlignment = 2; // 0 = esquerda, 1 = centro, 2 = direita
                tabela.AddCell(total);

                document.Add(tabela);

                document.Close();

                output.Seek(0, SeekOrigin.Begin);

                return output;
            }
        }


    }
}
