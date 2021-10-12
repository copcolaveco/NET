Public Class FormProlesa
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
        cargarLista()
        limpiar()
    End Sub

#End Region
    Private Sub cargarlista()
        Dim p As New dProlesa
        Dim lista As New ArrayList
        lista = p.listar
        DataGridView1.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView1.Rows.Add(lista.Count)
                For Each p In lista
                    DataGridView1(columna, fila).Value = p.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = p.NROSUC
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = p.SUCURSAL
                    columna = 0
                    fila = fila + 1
                Next
                'DataGridView1.Sort(DataGridView1.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
            End If
        End If
    End Sub
    Private Sub limpiar()
        TextId.Text = ""
        TextNumSucursal.Text = ""
        TextSucursal.Text = ""
        TextDireccion.Text = ""
        TextTelefono.Text = ""
        TextEncargado.Text = ""
        TextEmail.Text = ""
        cargarlista()
        TextNumSucursal.Focus()
    End Sub

    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        If TextNumSucursal.Text.Trim.Length = 0 Then MsgBox("No se ha ingresado el número", MsgBoxStyle.Exclamation, "Atención") : TextNumSucursal.Focus() : Exit Sub
        Dim numero As String = TextNumSucursal.Text.Trim
        Dim sucursal As String = ""
        If TextSucursal.Text <> "" Then
            sucursal = TextSucursal.Text.Trim
        End If
        Dim direccion As String = ""
        If TextDireccion.Text <> "" Then
            direccion = TextDireccion.Text.Trim
        End If
        Dim telefono As String = ""
        If TextTelefono.Text <> "" Then
            telefono = TextTelefono.Text.Trim
        End If
        Dim encargado As String = ""
        If TextEncargado.Text <> "" Then
            encargado = TextEncargado.Text.Trim
        End If
        Dim email As String = ""
        If TextEmail.Text <> "" Then
            email = TextEmail.Text.Trim
        End If
        If TextId.Text <> "" Then
            Dim p As New dProlesa
            Dim id As Long = TextId.Text.Trim
            p.ID = id
            p.NROSUC = numero
            p.SUCURSAL = sucursal
            p.DIRECCION = direccion
            p.TELEFONO = telefono
            p.ENCARGADO = encargado
            p.MAIL = email
            If (p.modificar(Usuario)) Then
                MsgBox("Registro modificado", MsgBoxStyle.Information, "Atención")
                limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        Else
            Dim p As New dProlesa
           p.NROSUC = numero
            p.SUCURSAL = sucursal
            p.DIRECCION = direccion
            p.TELEFONO = telefono
            p.ENCARGADO = encargado
            p.MAIL = email
            If (p.guardar(Usuario)) Then
                MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
                limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
    End Sub

    Private Sub ButtonNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNuevo.Click
        limpiar()
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If DataGridView1.Columns(e.ColumnIndex).Name = "Numero" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim p As New dProlesa
            id = row.Cells("Id").Value
            p.ID = id
            p = p.buscar
            If Not p Is Nothing Then
                TextId.Text = p.ID
                TextNumSucursal.Text = p.NROSUC
                TextSucursal.Text = p.SUCURSAL
                TextDireccion.Text = p.DIRECCION
                TextTelefono.Text = p.TELEFONO
                TextEncargado.Text = p.ENCARGADO
                TextEmail.Text = p.MAIL
            End If
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "Sucursal" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim p As New dProlesa
            id = row.Cells("Id").Value
            p.ID = id
            p = p.buscar
            If Not p Is Nothing Then
                TextId.Text = p.ID
                TextNumSucursal.Text = p.NROSUC
                TextSucursal.Text = p.SUCURSAL
                TextDireccion.Text = p.DIRECCION
                TextTelefono.Text = p.TELEFONO
                TextEncargado.Text = p.ENCARGADO
                TextEmail.Text = p.MAIL
            End If
        End If
    End Sub
End Class