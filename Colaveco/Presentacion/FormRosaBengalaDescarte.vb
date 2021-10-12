Public Class FormRosaBengalaDescarte
    Private _usuario As dUsuario
    Public Property Usuario() As dUsuario
        Get
            Return _usuario
        End Get
        Set(ByVal value As dUsuario)
            _usuario = value
        End Set
    End Property
    Public Sub New(ByVal u As dUsuario)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u
        limpiar()
        cargarlista()
    End Sub
    Private Sub limpiar()
        DateFecha.Value = Now
    End Sub
    Private Sub cargarlista()
        Dim r As New dRosaBengalaDescarte
        Dim lista As New ArrayList
        lista = r.listarpendientes

        DataGridView1.Rows.Clear()

        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView1.Rows.Add(lista.Count)
                For Each r In lista
                    DataGridView1(columna, fila).Value = r.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = r.FICHA
                    columna = columna + 1
                    If r.DESCARTADA = 1 Then
                        DataGridView1(columna, fila).Value = "Si"
                        DataGridView1(columna, fila).Style.BackColor = Color.Yellow
                        columna = columna + 1
                    Else
                        DataGridView1(columna, fila).Value = "No"
                        columna = columna + 1
                    End If
                   
                    If r.MARCADA = 1 Then
                        DataGridView1(columna, fila).Value = "Si"
                        DataGridView1(columna, fila).Style.BackColor = Color.Yellow
                        columna = columna + 1
                    Else
                        DataGridView1(columna, fila).Value = "No"
                        columna = columna + 1
                      
                    End If
                    DataGridView1(columna, fila).Value = r.FECHAM
                    columna = 0
                    fila = fila + 1
                    
                Next
                'DataGridView1.Sort(DataGridView1.Columns(1), System.ComponentModel.ListSortDirection.Ascending)

            End If
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If DataGridView1.Columns(e.ColumnIndex).Name = "Descartar" Then
            Dim fechadescarte As Date = DateFecha.Value.ToString("yyyy-MM-dd")
            Dim fechad As String
            fechad = Format(fechadescarte, "yyyy-MM-dd")
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim r As New dRosaBengalaDescarte
            id = row.Cells("Id").Value
            r.ID = id
            r.FECHAD = fechad
            r.descartar(Usuario)
            cargarlista()
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "Marcar" Then
            Dim fechamarca As Date = DateFecha.Value.ToString("yyyy-MM-dd")
            Dim fecham As String
            fecham = Format(fechamarca, "yyyy-MM-dd")
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim ficha As Long = 0
            Dim r As New dRosaBengalaDescarte
            Dim s As New dSolicitudAnalisis
            id = row.Cells("Id").Value
            ficha = row.Cells("Ficha").Value
            r.ID = id
            r.FECHAM = fecham
            r.marcar(Usuario)
            s.ID = ficha
            s.FECHAENVIO = fecham
            s.marcar3(Usuario)
            cargarlista()
        End If
    End Sub
End Class