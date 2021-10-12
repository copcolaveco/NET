Public Class FormBuscarBrucelosisLeche
    Private _usuario As dUsuario

    Public Property Usuario() As dUsuario
        Get
            Return _usuario
        End Get
        Set(ByVal value As dUsuario)
            _usuario = value
        End Set
    End Property
#Region "Constructores"
    Public Sub New(ByVal u As dUsuario)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u

    End Sub
#End Region

    Private Sub ButtonBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBuscar.Click
        If TextFicha.TextLength > 0 Then
            cargarlista()
        End If
    End Sub
    Private Sub cargarlista()
        Dim b As New dBrucelosis
        Dim lista As New ArrayList
        Dim ficha As Long = TextFicha.Text
        lista = b.listarporsolicitud(ficha)
        DataGridView1.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView1.Rows.Add(lista.Count)
                For Each b In lista
                    DataGridView1(columna, fila).Value = b.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = b.FICHA
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = b.MUESTRA
                    columna = columna + 1
                    If b.RESULTADO = 1 Then
                        DataGridView1(columna, fila).Value = "Positivo"
                        columna = 0
                        fila = fila + 1
                    Else
                        DataGridView1(columna, fila).Value = "Negativo"
                        columna = 0
                        fila = fila + 1
                    End If
                Next
                'DataGridView1.Sort(DataGridView1.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If DataGridView1.Columns(e.ColumnIndex).Name = "GuardarCambios" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim ficha As Long = 0
            Dim muestra As String = ""
            Dim b As New dBrucelosis
            id = row.Cells("Id").Value
            ficha = row.Cells("Ficha").Value
            muestra = row.Cells("Muestra").Value
            b.ID = id
            b.FICHA = ficha
            b.MUESTRA = muestra
            b.modificar2(Usuario)
        End If
    End Sub
End Class