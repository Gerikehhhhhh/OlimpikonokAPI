using OlimpikonokAPI.Models;

namespace OlimpikonokAPI.Services;

public class OrszagService
{
    public List<Orszag> GetAll()
    {
        try
        {
            List<Orszag> eredmeny = new OlimpikonokContext().Orszags.ToList();
            return eredmeny;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message, e);
        }
    }
}