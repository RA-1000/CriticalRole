using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Conjuros30
{
    public partial class frmCargar : Form
    {
        public frmCargar()
        {
            InitializeComponent();
        }

        private void bBuscar_Click(object sender, EventArgs e)
        {
            // Instanciamos el contexto y cargamos un listado
            ConjurosEntities db = new ConjurosEntities();

            long idConjuroBuscar = long.Parse(tbIDBuscar.Text);

            CONJURO conj = (from c in db.CONJURO
                            where c.ID_CONJURO == idConjuroBuscar
                            select c).FirstOrDefault();

            // Cargamos el encontrado
            LimpiarPantalla();
            CargarConjuro(conj);
        }

        private void CargarConjuro(CONJURO conj)
        {
            if (conj != null)
            {
                tbID.Text = conj.ID_CONJURO.ToString();
                tbNombre.Text = conj.NOMBRE;
                tbEscuela.Text = conj.ESCUELA;
                tbNivel.Text = conj.NIVEL;
                tbComponentes.Text = conj.COMPONENTES;
                tbTLanz.Text = conj.TIEMPO_LANZAMIENTO;
                tbAlcance.Text = conj.ALCANCE;
                tbAreaEfecto.Text = conj.AREA_EFECTO;
                tbDuracion.Text = conj.DURACION;
                tbTSalvacion.Text = conj.TIRADA_SALVACION;
                tbResistencia.Text = conj.RESISTENCIA;
                tbDescripcion.Text = conj.DESCRIPCION;
            }
        }

        private void LimpiarPantalla()
        {
            tbID.Text = string.Empty;
            tbNombre.Text = string.Empty;
            tbEscuela.Text = string.Empty;
            tbNivel.Text = string.Empty;
            tbComponentes.Text = string.Empty;
            tbTLanz.Text = string.Empty;
            tbAlcance.Text = string.Empty;
            tbAreaEfecto.Text = string.Empty;
            tbDuracion.Text = string.Empty;
            tbTSalvacion.Text = string.Empty;
            tbResistencia.Text = string.Empty;
            tbDescripcion.Text = string.Empty;
        }

        private void bGuardar_Click(object sender, EventArgs e)
        {
            // Instanciamos el contexto y cargamos un listado
            ConjurosEntities db = new ConjurosEntities();

            // Si el id está vacío, se tratará de una inserción
            if (String.IsNullOrEmpty(tbID.Text))
            {
                // Creamos un nuevo libro y lo añadimos, guardando a continuación los cambios
                CONJURO c = new CONJURO
                {
                    NOMBRE = tbNombre.Text,
                    ESCUELA = tbEscuela.Text,
                    NIVEL = tbNivel.Text,
                    COMPONENTES = tbComponentes.Text,
                    TIEMPO_LANZAMIENTO = tbTLanz.Text,
                    ALCANCE = tbAlcance.Text,
                    AREA_EFECTO = tbAreaEfecto.Text,
                    DURACION = tbDuracion.Text,
                    TIRADA_SALVACION = tbTSalvacion.Text,
                    RESISTENCIA = tbResistencia.Text,
                    DESCRIPCION = tbDescripcion.Text,
                };
                db.CONJURO.Add(c);
                db.SaveChanges();
            }
            else // En caso contrario, se tratará de una modificación
            {
                // Recuperamos el conjuro cuyo identificador coincida con el ID
                long cid = long.Parse(tbID.Text);
                CONJURO c = db.CONJURO.Where(conj => conj.ID_CONJURO == cid).First();

                // Modificamos el contenido
                c.NOMBRE = tbNombre.Text;
                c.ESCUELA = tbEscuela.Text;
                c.NIVEL = tbNivel.Text;
                c.COMPONENTES = tbComponentes.Text;
                c.TIEMPO_LANZAMIENTO = tbTLanz.Text;
                c.ALCANCE = tbAlcance.Text;
                c.AREA_EFECTO = tbAreaEfecto.Text;
                c.DURACION = tbDuracion.Text;
                c.TIRADA_SALVACION = tbTSalvacion.Text;
                c.RESISTENCIA = tbResistencia.Text;
                c.DESCRIPCION = tbDescripcion.Text;

                // Guardamos los cambios
                db.SaveChanges();
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarPantalla();
        }
    }
}
