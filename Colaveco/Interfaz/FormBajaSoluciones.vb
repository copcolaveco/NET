Public Class FormBajaSoluciones
#Region "Atributos"
    Private _usuario As dUsuario
    Private id_solucion As Integer = 0
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
        cargarlista()
        cargarunidades()
        cargarsoluciones()
        limpiar()
    End Sub
#End Region
    Private Sub cargarlista()
        Dim s As New dSolucionTrabajoBajas
        Dim lista As New ArrayList
        lista = s.listar
        DataGridView1.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView1.Rows.Add(lista.Count)
                For Each s In lista
                    DataGridView1(columna, fila).Value = s.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = s.FECHA
                    columna = columna + 1
                    Dim st As New dSolucionTrabajo
                    st.ID = s.IDSOLUCION
                    st = st.buscar
                    If Not st Is Nothing Then
                        DataGridView1(columna, fila).Value = st.NOMBRE
                        columna = 0
                        fila = fila + 1
                        st = Nothing
                    Else
                        DataGridView1(columna, fila).Value = ""
                        columna = 0
                        fila = fila + 1
                        st = Nothing
                    End If
                Next
                'DataGridView1.Sort(DataGridView1.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
            End If
        End If
    End Sub
    Public Sub cargarUnidades()
        Dim uni As New dUnidades
        Dim lista As New ArrayList
        lista = uni.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each uni In lista
                    ComboUnidad.Items.Add(uni)
                Next
            End If
        End If
    End Sub
    Public Sub cargarsoluciones()
        Dim s As New dSolucionTrabajo
        Dim lista As New ArrayList
        lista = s.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each s In lista
                    ComboSolucion.Items.Add(s)
                Next
            End If
        End If
    End Sub
    Private Sub limpiar()
        TextId.Text = ""
        ComboSolucion.SelectedItem = Nothing
        ComboSolucion.Text = ""
        TextCantidad.Text = ""
        ComboUnidad.SelectedItem = Nothing
        ComboUnidad.Text = ""
        cargarlista()
        ComboSolucion.Focus()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim fecha As Date = DateFecha.Value.ToString("yyyy-MM-dd")
        Dim fec As String
        fec = Format(fecha, "yyyy-MM-dd")
        If ComboSolucion.Text.Trim.Length = 0 Then MsgBox("Seleccione una solución", MsgBoxStyle.Exclamation, "Atención") : ComboSolucion.Focus() : Exit Sub
        Dim solucion As dSolucionTrabajo = CType(ComboSolucion.SelectedItem, dSolucionTrabajo)
        id_solucion = solucion.ID
        Dim cantidad As Double = 0
        If TextCantidad.Text <> "" Then
            cantidad = TextCantidad.Text
        End If
        If ComboUnidad.Text.Trim.Length = 0 Then MsgBox("Seleccione una unidad", MsgBoxStyle.Exclamation, "Atención") : ComboUnidad.Focus() : Exit Sub
        Dim unidad As dUnidades = CType(ComboUnidad.SelectedItem, dUnidades)
        

        If TextId.Text <> "" Then
            Dim s As New dSolucionTrabajoBajas
            Dim id As Long = TextId.Text.Trim
            s.ID = id
            s.FECHA = fec
            s.IDSOLUCION = solucion.ID
            s.CANTIDAD = cantidad
            s.IDUNIDAD = unidad.ID
            If (s.modificar(Usuario)) Then
                MsgBox("Registro modificado", MsgBoxStyle.Information, "Atención")
                limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        Else
            Dim s As New dSolucionTrabajoBajas
            s.FECHA = fec
            s.IDSOLUCION = solucion.ID
            s.CANTIDAD = cantidad
            s.IDUNIDAD = unidad.ID
            If (s.guardar(Usuario)) Then
                bajarstock()
                MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
                limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
    End Sub
    Private Sub bajarstock()

    End Sub
    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If DataGridView1.Columns(e.ColumnIndex).Name = "Fecha" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim s As New dSolucionTrabajoBajas
            id = row.Cells("Id").Value
            s.ID = id
            s = s.buscar
            If Not s Is Nothing Then
                TextId.Text = s.ID
                DateFecha.Value = s.FECHA
                Dim st As dSolucionTrabajo
                ComboSolucion.SelectedItem = Nothing
                For Each st In ComboSolucion.Items
                    If st.ID = s.IDSOLUCION Then
                        ComboSolucion.SelectedItem = st
                        Exit For
                    End If
                Next
                TextCantidad.Text = s.CANTIDAD
                Dim u As dUnidades
                ComboUnidad.SelectedItem = Nothing
                For Each u In ComboUnidad.Items
                    If u.ID = s.IDUNIDAD Then
                        ComboUnidad.SelectedItem = u
                        Exit For
                    End If
                Next
            End If
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "Solucion" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim s As New dSolucionTrabajoBajas
            id = row.Cells("Id").Value
            s.ID = id
            s = s.buscar
            If Not s Is Nothing Then
                TextId.Text = s.ID
                DateFecha.Value = s.FECHA
                Dim st As dSolucionTrabajo
                ComboSolucion.SelectedItem = Nothing
                For Each st In ComboSolucion.Items
                    If st.ID = s.IDSOLUCION Then
                        ComboSolucion.SelectedItem = st
                        Exit For
                    End If
                Next
                TextCantidad.Text = s.CANTIDAD
                Dim u As dUnidades
                ComboUnidad.SelectedItem = Nothing
                For Each u In ComboUnidad.Items
                    If u.ID = s.IDUNIDAD Then
                        ComboUnidad.SelectedItem = u
                        Exit For
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub ButtonNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNuevo.Click
        limpiar()
    End Sub
End Class