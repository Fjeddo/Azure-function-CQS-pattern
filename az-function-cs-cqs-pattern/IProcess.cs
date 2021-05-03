using System.Threading.Tasks;

namespace az_function_cs_cqs_pattern
{
    public interface IProcess<TIn, TOut>
    {
        Task<(bool success, TOut model, int status)> Run(TIn request);
    }
}
