using System.Threading.Tasks;

namespace az_func_cs_cqs_pattern.Code
{
    public interface IProcess<TIn, TOut>
    {
        Task<(bool success, TOut model, int status)> Run(TIn request);
    }
}
