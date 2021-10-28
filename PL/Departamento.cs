using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Departamento
    {
        //ADD SP
        public static void AddSP()
        {
            ML.Departamento departamento = new ML.Departamento();

            Console.WriteLine("Ingresa el nombre del departamento");
            departamento.Nombre = Console.ReadLine();
            
            Console.WriteLine("Ingresa idArea del departamento");
            departamento.Area = new ML.Area();
            departamento.Area.IdArea = int.Parse(Console.ReadLine());

            //ML.Result result = BL.Departamento.AddSP(departamento);
            //ML.Result result = BL.Departamento.AddEF(departamento);
            //ML.Result result = BL.Departamento.AddLINQ(departamento);

            ServiceReferenceDepartamento.ServicioDepartamentoClient client = new ServiceReferenceDepartamento.ServicioDepartamentoClient();
            var result = client.Add(departamento);
            //ServiceReferenceMateria.ServiceMateriaClient client = new ServiceReferenceMateria.ServiceMateriaClient();
            //var result = client.Add(materia);

            if (result.Correct)
            {
                Console.WriteLine("Departamento ingresado correctamente");
            }
            else
            {
                Console.WriteLine("Ocurrió un error al insertar el registro en la tabla Departamento " + result.ErrorMessage);
            }

        }

        //DELETE SP
        public static void DeleteSP()
        {
            ML.Departamento departamento = new ML.Departamento();

            Console.WriteLine("Ingresa el id del Departamento que desea eliminar");
            departamento.IdDepartamento = int.Parse(Console.ReadLine());

            //ML.Result result = BL.Departamento.DeleteSP(departamento);
            //ML.Result result = BL.Departamento.DeleteEF(departamento);
            //ML.Result result = BL.Departamento.DeleteLINQ(departamento);

            ServiceReferenceDepartamento.ServicioDepartamentoClient client = new ServiceReferenceDepartamento.ServicioDepartamentoClient();
            var result = client.Delete(departamento.IdDepartamento);


            if (result.Correct)
            {
                Console.WriteLine("Departamento eliminado correctamente");
            }
            else
            {
                Console.WriteLine("Ocurrió un error al borrar el registro en la tabla Departamento " + result.ErrorMessage);
            }

        }

        //UPDATE
        public static void UpdateSP()
        {
            ML.Departamento departamento = new ML.Departamento();

            Console.WriteLine("Ingresa el id del departamento que desea modificar");
            departamento.IdDepartamento = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingresa el nuevo nombre del departamento");
            departamento.Nombre = Console.ReadLine();

            Console.WriteLine("Ingresa el nuevo IdArea del departamento");
            departamento.Area = new ML.Area();
            departamento.Area.IdArea = int.Parse(Console.ReadLine());


            //ML.Result result = BL.Departamento.UpdateSP(departamento);
            //ML.Result result = BL.Departamento.UpdateEF(departamento);
            //ML.Result result = BL.Departamento.UpdateLINQ(departamento);

            ServiceReferenceDepartamento.ServicioDepartamentoClient client = new ServiceReferenceDepartamento.ServicioDepartamentoClient();
            var result = client.Update(departamento);

            if (result.Correct)
            {
                Console.WriteLine("Departamento actualizado correctamente");
            }
            else
            {
                Console.WriteLine("Ocurrió un error al actualizar el registro en la tabla Departamento " + result.ErrorMessage);
            }

        }

        //GetAllSP
        public static void GetAllSP()
        {

            //ML.Result result = BL.Departamento.GetAllEF();
            //ML.Result result = BL.Departamento.GetAllLINQ();

            ServiceReferenceDepartamento.ServicioDepartamentoClient client = new ServiceReferenceDepartamento.ServicioDepartamentoClient();
            var result = client.GetAll();


            if (result.Correct)
            {
                foreach (ML.Departamento departamento in result.Objects)
                {
                    Console.WriteLine("IdDepartamento: " + departamento.IdDepartamento);
                    Console.WriteLine("Nombre: " + departamento.Nombre);
                    Console.WriteLine("IdArea: " + departamento.Area.IdArea );
                    Console.WriteLine("----------------------------------------\n");

                }
            }
            else
            {
                Console.WriteLine("Ocurrió un error al consultar la información" + result.ErrorMessage);
            }
        }

        //GetByID
        public static void GetByIdSP()
        {
            ML.Departamento departamento = new ML.Departamento();

            Console.WriteLine("Ingrese el Id del departamento que quiera visualizar ");
            departamento.IdDepartamento = int.Parse(Console.ReadLine());

            //ML.Result result = BL.Departamento.GetByIdSP(departamento);
            //ML.Result result = BL.Departamento.GetByIdEF(departamento.IdDepartamento);
            ServiceReferenceDepartamento.ServicioDepartamentoClient client = new ServiceReferenceDepartamento.ServicioDepartamentoClient();
            var result = client.GetById(departamento.IdDepartamento);

            if (result.Correct)
            {
                departamento = (ML.Departamento)result.Object;
                
                
                    Console.WriteLine("IdDepartamento: " + departamento.IdDepartamento);
                    Console.WriteLine("Nombre: " + departamento.Nombre);
                    Console.WriteLine("IdArea: " + departamento.Area.IdArea + "\n");
                
            }
            else
            {
                Console.WriteLine("Ocurrió un error al consultar la información" + result.ErrorMessage);
            }
        }


    }
}
