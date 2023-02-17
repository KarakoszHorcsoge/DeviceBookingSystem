using System.Text;
using back.models.Administrators;

namespace back.common.loghelper;

static class Comparer{
    public static string partStringBuilder(Administrator admin){
        return $"Id: {admin.Id}; Name: {admin.Name}; "+
        $"Email: {admin.Email}; AuthorotyId: {admin.AuthorotyId} "+ 
        $"CreationTime: {admin.CreationTime}; Creator: {admin.CreatorId}; "+
        $"ModificationTime: {admin.ModificationTime}; ModifierId: {admin.ModifierId}";
    }
    public static string getDiff(Administrator adminOld,Administrator adminNew){
        StringBuilder result = new StringBuilder(300);
        
        if(adminNew.Name!=adminOld.Name)    {result.Append($"From: {adminOld.Name} To: {adminNew.Name}; ");}
        if(adminNew.Email!=adminOld.Email)    {result.Append($"From: {adminOld.Email} To: {adminNew.Email}; ");}
        if(adminNew.AuthorotyId!=adminOld.AuthorotyId)    {result.Append($"From: {adminOld.AuthorotyId} To: {adminNew.AuthorotyId}; ");}
        result.Append($"From: {adminOld.ModificationTime} To: {adminNew.ModificationTime}; ");
        if(adminNew.ModifierId!=adminOld.ModifierId)    {result.Append($"From: {adminOld.ModifierId} To: {adminNew.ModifierId};");}

        return result.ToString();
    }
}