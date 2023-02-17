using System.Text;
using back.models.Administrators;

namespace back.common.loghelper;

static class Comparer{

    public static string partStringBuilder(Administrator admin){
        return $"Id: {admin.Id}; Name: {admin.Name}; "+
        "Email: {admin.Email}; AuthorotyId: {admin.AuthorotyId} "+ 
        "CreationTime: {admin.CreationTime}; Creator: {admin.CreatorId}; "+
        "ModificationTime: {admin.ModificationTime}; ModifierId: {admin.ModifierId}";
    }
    public static string getDiff(Administrator adminOld,Administrator adminNew){
        var result = "";

        

        return result;
    }
}