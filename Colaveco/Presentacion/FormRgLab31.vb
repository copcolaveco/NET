Public Class FormRgLab31
    Private _usuario As dUsuario
    Dim _hora As String
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
        cargarlista()
        cargarCombos()
        cargarComboAnalisis()
        limpiar()
    End Sub

    Private Sub cargarlista()
        Dim r As New dRgLab31
        Dim lista As New ArrayList
        lista = r.listar
        DataGridView1.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView1.Rows.Add(lista.Count)
                For Each r In lista
                    DataGridView1(columna, fila).Value = r.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = r.FECHA
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = r.FICHA
                    columna = 0
                    fila = fila + 1
                Next
                'DataGridView1.Sort(DataGridView1.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
            End If
        End If
    End Sub
    Public Sub cargarCombos()
        Dim u As New dUsuario
        Dim lista As New ArrayList
        lista = u.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each u In lista
                    ComboOperador.Items.Add(u)
                    ComboEliminado.Items.Add(u)
                Next
            End If
        End If
    End Sub
    Public Sub cargarComboAnalisis()
        Dim ti As New dTipoInforme
        Dim lista As New ArrayList
        lista = ti.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each ti In lista
                    ComboAnalisis.Items.Add(ti)
                Next
            End If
        End If
    End Sub
    Public Sub limpiar()
        _hora = Now.ToString("HH:mm")
        TextId.Text = ""
        DateFecha.Value = Now
        TextHora.Text = _hora
        TextFicha.Text = ""
        TextCantidad.Text = ""
        ComboAnalisis.Text = ""
        ComboOperador.Text = ""
        TextTemperatura.Text = ""
        TextHumedad.Text = ""
        ComboEliminado.Text = ""
        TextObservaciones.Text = ""
        TextFicha.Select()
    End Sub

    Private Sub ButtonNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNuevo.Click
        limpiar()
        cargarLista()
    End Sub

    Private Sub ButtonEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEliminar.Click
        If TextId.Text <> "" Then
            If MsgBox("El registro será eliminado, ¿desea continuar?", MsgBoxStyle.OkCancel, "Atención") = MsgBoxResult.Ok Then
                Dim r As New dRgLab31
                Dim id As Long = CType(TextId.Text, Long)
                r.ID = id
                If (r.eliminar(Usuario)) Then
                    MsgBox("Registro eliminado", MsgBoxStyle.Information, "Atención")
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If
        End If
        limpiar()
        cargarLista()
    End Sub

    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click

        Dim fecha As Date = DateFecha.Value.ToString("yyyy-MM-dd")
        Dim hora As String = TextHora.Text.Trim
        Dim ficha As Long = TextFicha.Text.Trim
        Dim cantidad As Double = TextCantidad.Text
        Dim idtipoinforme As dTipoInforme = CType(ComboAnalisis.SelectedItem, dTipoInforme)
        Dim operador As dUsuario = CType(ComboOperador.SelectedItem, dUsuario)
        Dim temperatura As Double = TextTemperatura.Text.Trim
        Dim humedad As Double = TextHumedad.Text.Trim
        Dim eliminado As dUsuario = CType(ComboEliminado.SelectedItem, dUsuario)
        Dim observaciones As String = TextObservaciones.Text
        'If TextIdProductor.Text.Trim.Length = 0 Then MsgBox("No se ha ingresado el número de productor", MsgBoxStyle.Exclamation, "Atención") : TextIdProductor.Focus() : Exit Sub

        If TextId.Text.Trim.Length > 0 Then
            Dim r As New dRgLab31()
            Dim id As Long = CType(TextId.Text.Trim, Long)
            Dim fec As String
            fec = Format(fecha, "yyyy-MM-dd")
            r.ID = id
            r.FECHA = fec
            r.HORA = hora
            r.FICHA = ficha
            r.CANTIDAD = cantidad
            If Not idtipoinforme Is Nothing Then
                r.IDTIPOINFORME = idtipoinforme.ID
            Else
                MsgBox("Falta ingresar el tipo de análisis")
                ComboOperador.Focus()
                Exit Sub
            End If
            If Not operador Is Nothing Then
                r.OPERADOR = operador.ID
            Else
                MsgBox("Falta ingresar el operador")
                ComboOperador.Focus()
                Exit Sub
            End If
            r.TEMPERATURA = temperatura
            r.HUMEDAD = humedad
            If Not eliminado Is Nothing Then
                r.ELIMINADO = eliminado.ID
            Else
                MsgBox("Falta ingresar la persona que elimina las muestras")
                ComboEliminado.Focus()
                Exit Sub
            End If
            r.OBSERVACIONES = observaciones
            If (r.modificar(Usuario)) Then
                MsgBox("Registro modificado", MsgBoxStyle.Information, "Atención")
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        Else
            Dim r As New dRgLab31()
            'Dim id As Long = CType(TextId.Text.Trim, Long)
            Dim fec As String
            fec = Format(fecha, "yyyy-MM-dd")
            r.FECHA = fec
            r.HORA = hora
            r.FICHA = ficha
            r.CANTIDAD = cantidad
            If Not idtipoinforme Is Nothing Then
                r.IDTIPOINFORME = idtipoinforme.ID
            Else
                MsgBox("Falta ingresar el tipo de análisis")
                ComboOperador.Focus()
                Exit Sub
            End If
            If Not operador Is Nothing Then
                r.OPERADOR = operador.ID
            Else
                MsgBox("Falta ingresar el operador")
                ComboOperador.Focus()
                Exit Sub
            End If
            r.TEMPERATURA = temperatura
            r.HUMEDAD = humedad
            If Not eliminado Is Nothing Then
                r.ELIMINADO = eliminado.ID
            Else
                MsgBox("Falta ingresar la persona que elimina las muestras")
                ComboEliminado.Focus()
                Exit Sub
            End If
            r.OBSERVACIONES = observaciones
            If (r.guardar(Usuario)) Then
                MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
                limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
        cargarLista()
        limpiar()
    End Sub

    Private Sub TextFicha_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextFicha.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            Dim sa As New dSolicitudAnalisis
            Dim ficha As Long = 0
            Dim tinf As Integer = 0
            Dim cantidad As Integer = 0
            ficha = TextFicha.Text
            sa.ID = ficha
            sa = sa.buscar
            If Not sa Is Nothing Then
                tinf = sa.IDTIPOINFORME
                cantidad = sa.NMUESTRAS
            End If

            ComboAnalisis.SelectedItem = Nothing
            Dim ti As New dTipoInforme
            For Each ti In ComboAnalisis.Items
                If ti.ID = tinf Then
                    ComboAnalisis.SelectedItem = ti
                    Exit For
                End If
            Next

            ComboOperador.SelectedItem = Nothing
            Dim usu As New dUsuario
            For Each usu In ComboOperador.Items
                If usu.ID = Usuario.ID Then
                    ComboOperador.SelectedItem = usu
                    ComboEliminado.SelectedItem = usu
                    Exit For
                End If
            Next

            TextCantidad.Text = cantidad
            TextTemperatura.Focus()
        End If
    End Sub

   
    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If DataGridView1.Columns(e.ColumnIndex).Name = "Fecha" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim r As New dRgLab31
            id = row.Cells("Id").Value
            r.ID = id
            r = r.buscar
            If Not r Is Nothing Then
                TextId.Text = r.ID
                DateFecha.Value = r.FECHA
              
            End If
        End If
    End Sub
End Class