using Angelix_Vasquez_AP1_P2.DAL;
using Angelix_Vasquez_AP1_P2.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Angelix_Vasquez_AP1_P2.Services;

public class ProductoServices
{
    private readonly IDbContextFactory<Contexto> DbFactory;

    public ProductoServices(IDbContextFactory<Contexto> dbFactory)
    {
        DbFactory = dbFactory;
    }

    public async Task<bool> Existe(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Productos.AnyAsync(p => p.ProductosId == id);
    }

    private async Task<bool> Insertar(Producto producto)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();

        contexto.Productos.Add(producto);

        // Verificar que los detalles de las entradas sean válidos
        foreach (var detalle in producto.EntradasDetalle)
        {
            if (detalle.ProductoId <= 0)
                throw new InvalidOperationException($"ProductoId {detalle.ProductoId} no es válido en el detalle.");
        }

        return await contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(Producto producto)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();

        contexto.Entry(producto).State = EntityState.Modified;

        // Modificar las entradas asociadas si es necesario
        foreach (var detalle in producto.EntradasDetalle)
        {
            if (detalle.EntradasId == 0)
            {
                contexto.Entry(detalle).State = EntityState.Added;
            }
            else
            {
                contexto.Entry(detalle).State = EntityState.Modified;
            }

            if (detalle.ProductoId <= 0)
                throw new InvalidOperationException($"ProductoId {detalle.ProductoId} no es válido en el detalle.");
        }

        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(Producto producto)
    {
        if (!await Existe(producto.ProductosId))
            return await Insertar(producto);
        else
            return await Modificar(producto);
    }

    public async Task<bool> Eliminar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var eliminado = await contexto.Productos
            .Where(p => p.ProductosId == id)
            .ExecuteDeleteAsync();

        return eliminado > 0;
    }

    public async Task<Producto?> Buscar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Productos
            .Include(p => p.EntradasDetalle)  // Incluir EntradasDetalle para poder acceder a los detalles
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.ProductosId == id);
    }

    public async Task<List<Producto>> Listar(Expression<Func<Producto, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Productos
            .Include(p => p.EntradasDetalle)  // Incluir EntradasDetalle para poder acceder a los detalles
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }
}
