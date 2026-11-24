namespace LeitorXML.LeitorXml
{
    // interface do processador: quem implementar precisa ter o Processar
    public interface IProcessadorNfce
    {
        void Processar(string serie, string competencia);
    }
}
