Public Class FormProveedores
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
        Dim p As New dProveedores
        Dim lista As New ArrayList
        lista = p.listartodos
        DataGridView1.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView1.Rows.Add(lista.Count)
                For Each p In lista
                    DataGridView1(columna, fila).Value = p.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = p.NOMBRE
                    columna = 0
                    fila = fila + 1
                Next
                'DataGridView1.Sort(DataGridView1.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
            End If
        End If
    End Sub
    Private Sub limpiar()
        TextId.Text = ""
        TextNombre.Text = ""
        TextRut.Text = ""
        TextTelefono.Text = ""
        TextDireccion.Text = ""
        TextEmail.Text = ""
        TextEmail2.Text = ""
        TextEmail3.Text = ""
        TextContacto.Text = ""
        TextOtrosDatos.Text = ""
        cargarlista()
        TextNombre.Focus()
    End Sub

    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        If TextNombre.Text.Trim.Length = 0 Then MsgBox("No se ha ingresado el nombre", MsgBoxStyle.Exclamation, "Atención") : TextNombre.Focus() : Exit Sub
        Dim nombre As String = TextNombre.Text.Trim
        Dim rut As String = ""
        If TextRut.Text <> "" Then
            rut = TextRut.Text.Trim
        End If
        Dim telefono As String = ""
        If TextTelefono.Text <> "" Then
            telefono = TextTelefono.Text.Trim
        End If
        Dim direccion As String = ""
        If TextDireccion.Text <> "" Then
            direccion = TextDireccion.Text.Trim
        End If
        Dim email As String = ""
        If TextEmail.Text <> "" Then
            email = TextEmail.Text.Trim
        End If
        Dim email2 As String = ""
        If TextEmail2.Text <> "" Then
            email2 = TextEmail2.Text.Trim
        End If
        Dim email3 As String = ""
        If TextEmail3.Text <> "" Then
            email3 = TextEmail3.Text.Trim
        End If
        Dim contacto As String = ""
        If TextContacto.Text <> "" Then
            contacto = TextContacto.Text.Trim
        End If
        Dim otrosdatos As String = ""
        If TextOtrosDatos.Text <> "" Then
            otrosdatos = TextOtrosDatos.Text.Trim
        End If
        Dim nousar As Integer = 0
        If CheckNoUsar.Checked = True Then
            nousar = 1
        End If
        Dim critico As Integer = 0
        If cbxCritico.Checked = True Then
            critico = 1
        End If
        If TextId.Text <> "" Then
            Dim p As New dProveedores
            Dim id As Long = TextId.Text.Trim
            p.ID = id
            p.NOMBRE = nombre
            p.RUT = rut
            p.TELEFONO = telefono
            p.DIRECCION = direccion
            p.EMAIL = email
            p.EMAIL2 = email2
            p.EMAIL3 = email3
            p.CONTACTO = contacto
            p.OTROSDATOS = otrosdatos
            p.NOUSAR = nousar
            p.CRITICO = critico
            If (p.modificar(Usuario)) Then
                MsgBox("Registro modificado", MsgBoxStyle.Information, "Atención")
                limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        Else
            Dim p As New dProveedores
            p.NOMBRE = nombre
            p.RUT = rut
            p.TELEFONO = telefono
            p.DIRECCION = direccion
            p.EMAIL = email
            p.EMAIL2 = email2
            p.EMAIL3 = email3
            p.CONTACTO = contacto
            p.OTROSDATOS = otrosdatos
            p.NOUSAR = nousar
            p.CRITICO = critico
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

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If DataGridView1.Columns(e.ColumnIndex).Name = "Nombre" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim p As New dProveedores
            id = row.Cells("Id").Value
            p.ID = id
            p = p.buscar
            If Not p Is Nothing Then
                TextId.Text = p.ID
                TextNombre.Text = p.NOMBRE
                TextRut.Text = p.RUT
                TextTelefono.Text = p.TELEFONO
                TextDireccion.Text = p.DIRECCION
                TextEmail.Text = p.EMAIL
                TextEmail2.Text = p.EMAIL2
                TextEmail3.Text = p.EMAIL3
                TextContacto.Text = p.CONTACTO
                TextOtrosDatos.Text = p.OTROSDATOS
                If p.NOUSAR = 0 Then
                    CheckNoUsar.Checked = False
                Else
                    CheckNoUsar.Checked = True
                End If

                If p.CRITICO = 0 Then
                    cbxCritico.Checked = False
                Else
                    cbxCritico.Checked = True
                End If
            End If
        End If
    End Sub

    Private Sub ButtonTodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonTodos.Click
        cargarlista()
    End Sub

    Private Sub TextFiltro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextFiltro.TextChanged
        Dim nombre As String = TextFiltro.Text.Trim
        Dim p As New dProveedores
        Dim lista As New ArrayList
        lista = p.listarxnombre(nombre)
        DataGridView1.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView1.Rows.Add(lista.Count)
                For Each p In lista
                    DataGridView1(columna, fila).Value = p.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = p.NOMBRE
                    columna = 0
                    fila = fila + 1
                Next
                'DataGridView1.Sort(DataGridView1.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
            End If
        End If
    End Sub
End Class