using System;
using System.IO;
using System.Text;

namespace Teste
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var fs = new FileStream("teste.txt", FileMode.Create))
            {
                var escrita = "Miguel,21,Guaramar";
                var encoding = Encoding.Default;

                var bytes = encoding.GetBytes(escrita);

                fs.Write(bytes, 0, bytes.Length);
                //var conteudoArquivo = encoding.GetString(buffer, 0, bytesLidos);
            }

            //Console.Write();
        }
}
}
