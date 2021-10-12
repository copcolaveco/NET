Public Class FormTecnicoProductor
#Region "Atributos"
    Private _usuario As dUsuario
    Public Property Usuario() As dUsuario
        Get
            Return _usuario
        End Get
        Set(ByVal value As dUsuario)
            _usuario = value
        End Set
    End Property
#End Region
#Region "Constructores"
    Public Sub New(ByVal u As dUsuario)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u
        cargarTecnicos()
        cargarProductores()
        limpiar()
    End Sub

#End Region
    Public Sub cargarTecnicos()
        Dim t As New dCliente
        Dim listat As New ArrayList
        listat = t.listar
        DataGridTecnicos.Rows.Clear()
        If Not listat Is Nothing Then
            If listat.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridTecnicos.Rows.Add(listat.Count)
                For Each t In listat
                    DataGridTecnicos(columna, fila).Value = t.ID
                    columna = columna + 1
                    DataGridTecnicos(columna, fila).Value = t.NOMBRE
                    columna = 0
                    fila = fila + 1
                Next
            End If
        End If
    End Sub
    Public Sub cargarProductores()
        Dim p As New dCliente
        Dim listap As New ArrayList
        listap = p.listar
        DataGridProductores.Rows.Clear()
        If Not listap Is Nothing Then
            If listap.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridProductores.Rows.Add(listap.Count)
                For Each p In listap
                    DataGridProductores(columna, fila).Value = p.ID
                    columna = columna + 1
                    DataGridProductores(columna, fila).Value = p.NOMBRE
                    columna = 0
                    fila = fila + 1
                Next
            End If
        End If
    End Sub
    Private Sub limpiar()
        TextBuscarTecnico.Text = ""
        TextBuscarProductor.Text = ""
    End Sub

    Private Sub DataGridTecnicos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridTecnicos.CellContentClick
        If DataGridTecnicos.Columns(e.ColumnIndex).Name = "NombreTecnico" Then
            Dim row As DataGridViewRow = DataGridTecnicos.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim t As New dCliente
            id = row.Cells("IdTecnico").Value
            Dim p As New dCliente
            Dim lista As New ArrayList
            lista = p.listarxtecnico(id)
            DataGridProductores.Rows.Clear()
            If Not lista Is Nothing Then
                If lista.Count > 0 Then
                    Dim fila As Integer = 0
                    Dim columna As Integer = 0
                    DataGridProductores.Rows.Add(lista.Count)
                    For Each p In lista
                        DataGridProductores(columna, fila).Value = p.ID
                        columna = columna + 1
                        DataGridProductores(columna, fila).Value = p.NOMBRE
                        columna = 0
                        fila = fila + 1
                    Next
                End If
            End If
        End If
    End Sub

    Private Sub DataGridProductores_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridProductores.CellContentClick
        If DataGridProductores.Columns(e.ColumnIndex).Name = "NombreProductor" Then
            Dim row As DataGridViewRow = DataGridProductores.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim p As New dCliente
            id = row.Cells("IdProductor").Value
            p.ID = id
            p = p.buscar
            DataGridTecnicos.Rows.Clear()
            If Not p Is Nothing Then
                Dim t1 As New dCliente
                Dim t2 As New dCliente
                t1.ID = p.TECNICO1
                t2.ID = p.TECNICO2
                t1 = t1.buscar
                t2 = t2.buscar
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridTecnicos.Rows.Add(3)
                If Not t1 Is Nothing Then
                    DataGridTecnicos(columna, fila).Value = t1.ID
                    columna = columna + 1
                    DataGridTecnicos(columna, fila).Value = t1.NOMBRE
                    columna = 0
                    fila = fila + 1
                Else
                    DataGridTecnicos(columna, fila).Value = ""
                    columna = columna + 1
                    DataGridTecnicos(columna, fila).Value = ""
                    columna = 0
                    fila = fila + 1
                End If
                If Not t2 Is Nothing Then
                    DataGridTecnicos(columna, fila).Value = t2.ID
                    columna = columna + 1
                    DataGridTecnicos(columna, fila).Value = t2.NOMBRE
                    columna = 0
                    fila = fila + 1
                Else
                    DataGridTecnicos(columna, fila).Value = ""
                    columna = columna + 1
                    DataGridTecnicos(columna, fila).Value = ""
                    columna = 0
                    fila = fila + 1
                End If
            End If
        End If
    End Sub

    Private Sub TextBuscarTecnico_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBuscarTecnico.TextChanged
        Dim nombre As String = TextBuscarTecnico.Text.Trim
        If nombre.Length > 0 Then
            Dim t As New dCliente
            Dim listat As New ArrayList
            listat = t.buscarPorNombre(nombre)
            DataGridTecnicos.Rows.Clear()
            If Not listat Is Nothing And listat.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridTecnicos.Rows.Add(listat.Count)
                For Each t In listat
                    DataGridTecnicos(columna, fila).Value = t.ID
                    columna = columna + 1
                    DataGridTecnicos(columna, fila).Value = t.NOMBRE
                    columna = 0
                    fila = fila + 1
                Next
            End If
        End If
    End Sub

    Private Sub TextBuscarProductor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBuscarProductor.TextChanged
        Dim nombre As String = TextBuscarProductor.Text.Trim
        If nombre.Length > 0 Then
            Dim p As New dCliente
            Dim listap As New ArrayList
            listap = p.buscarPorNombreTodos(nombre)
            DataGridProductores.Rows.Clear()
            If Not listap Is Nothing And listap.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridProductores.Rows.Add(listap.Count)
                For Each p In listap
                    DataGridProductores(columna, fila).Value = p.ID
                    columna = columna + 1
                    DataGridProductores(columna, fila).Value = p.NOMBRE
                    columna = 0
                    fila = fila + 1
                Next
            End If
        End If
    End Sub

    Private Sub ButtonTodosTecnicos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonTodosTecnicos.Click
        cargarTecnicos()
    End Sub

    Private Sub ButtonTodosProductores_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonTodosProductores.Click
        cargarProductores()
    End Sub
End Class