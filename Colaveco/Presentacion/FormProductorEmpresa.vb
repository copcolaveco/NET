Public Class FormProductorEmpresa
#Region "Atributos"
    Private _usuario As dUsuario
    Private idprod As Long = 0
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
    Public Sub New(ByVal u As dUsuario, ByVal idproductor As Long)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        idprod = idproductor
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u
        cargarProductor()

        cargarProductorEmpresa()

    End Sub

#End Region
   
    Public Sub cargarProductor()
        Dim p As New dProductor
        p.ID = idprod
        p = p.buscar
        TextProductor.Text = p.NOMBRE
      
    End Sub
    Public Sub cargarProductorEmpresa()
        Dim pe As New dProductorEmpresa
        Dim p As New dProductor
        Dim lista As New ArrayList
        lista = pe.listarxid(idprod)
        DataGridView1.Rows.Clear()

        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView1.Rows.Add(lista.Count)
                For Each pe In lista
                    DataGridView1(columna, fila).Value = pe.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = pe.IDPRODUCTOR
                    columna = columna + 1
                    
                    DataGridView1(columna, fila).Value = pe.MATRICULA
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = pe.IDEMPRESA
                    columna = columna + 1
                    p.ID = pe.IDEMPRESA
                    p = p.buscar
                    If Not p Is Nothing Then
                        DataGridView1(columna, fila).Value = p.NOMBRE
                        columna = 0
                    Else
                        DataGridView1(columna, fila).Value = "vacío"
                        columna = 0
                    End If
                    fila = fila + 1
                Next
            End If
        End If
    End Sub

    Private Sub ButtonAgregarEmpresa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAgregarEmpresa.Click
        Dim v As New FormBuscarEmpresa
        v.ShowDialog()
        If Not v.Productor Is Nothing Then
            Dim pro As dProductor = v.Productor
            TextIdEmpresa.Text = pro.ID
            TextEmpresa.Text = pro.NOMBRE
            TextMatricula.Focus()
        End If
    End Sub

    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        guardar()
    End Sub
    Private Sub guardar()
        Dim idproductor As String = idprod
        Dim matricula As String = TextMatricula.Text.Trim
        Dim ideempresa As Long = TextIdEmpresa.Text.Trim
        If TextId.Text.Trim.Length > 0 Then
            Dim proemp As New dProductorEmpresa
            Dim id As Long = TextId.Text.Trim
            proemp.ID = id
            proemp.IDPRODUCTOR = idproductor
            proemp.MATRICULA = matricula
            proemp.IDEMPRESA = ideempresa
            If (proemp.modificar(Usuario)) Then
                MsgBox("Registro modificado", MsgBoxStyle.Information, "Atención")
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        Else
            Dim proemp As New dProductorEmpresa
            proemp.IDPRODUCTOR = idproductor
            proemp.MATRICULA = matricula
            proemp.IDEMPRESA = ideempresa
            If (proemp.guardar(Usuario)) Then
                MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
        limpiar()
        cargarProductorEmpresa()
    End Sub
    Private Sub limpiar()
        TextId.Text = ""
        TextMatricula.Text = ""
        TextEmpresa.Text = ""
        TextIdEmpresa.Text = ""
    End Sub
    Private Sub ButtonEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEliminar.Click
        If TextId.Text <> "" Then
            Dim pe As New dProductorEmpresa
            Dim id As Long = CType(TextId.Text, Long)
            pe.ID = id
            If (pe.eliminar(Usuario)) Then
                MsgBox("Registro eliminado", MsgBoxStyle.Information, "Atención")
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
        limpiar()
        cargarProductorEmpresa()
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If DataGridView1.Columns(e.ColumnIndex).Name = "Seleccionar" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim pe As New dProductorEmpresa
            Dim p As New dProductor
            id = row.Cells("Id").Value
            pe.ID = id
            pe = pe.buscar
            If Not pe Is Nothing Then
                TextId.Text = pe.ID
                TextMatricula.Text = pe.MATRICULA
                TextIdEmpresa.Text = pe.IDEMPRESA
                p.ID = pe.IDEMPRESA
                p = p.buscar
                If Not p Is Nothing Then
                    TextEmpresa.Text = p.NOMBRE
                End If

            End If
        End If

    End Sub
End Class