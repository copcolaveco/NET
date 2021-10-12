Public Class FormDescarteMuestras
    Private _usuario As dUsuario
    Private _ficha As Long
    Public Property Usuario() As dUsuario
        Get
            Return _usuario
        End Get
        Set(ByVal value As dUsuario)
            _usuario = value
        End Set
    End Property

#Region "Constructores"
    Public Sub New(ByVal u As dUsuario, ByVal id_ficha As Long)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u
        limpiar()
        _ficha = id_ficha
        TextFicha.Text = _ficha
        Dim s As New dSolicitudAnalisis
        s.ID = _ficha
        s = s.buscar
        If Not s Is Nothing Then
            Dim c As New dCliente
            c.ID = s.IDPRODUCTOR
            c = c.buscar
            If Not c Is Nothing Then
                TextIdProductor.Text = c.ID
                TextProductor.Text = c.NOMBRE
                ComboTipoInforme.Focus()
            End If
        End If
        'cargarComboMuestra()
        cargarComboTipoInforme()
        cargarComboMotivoDescarte()
        cargarComboInformacionRetorno()
        cargarComboAutorizacion()
        'cargarComboAgencia()
    End Sub
#End Region
    Public Sub cargarComboMuestra()
        Dim m As New dMuestras
        Dim lista As New ArrayList
        lista = m.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each m In lista
                    ComboMuestra.Items.Add(m)
                Next
            End If
        End If
    End Sub
    Public Sub cargarComboTipoInforme()
        Dim ti As New dTipoInforme
        Dim lista As New ArrayList
        lista = ti.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each ti In lista
                    ComboTipoInforme.Items.Add(ti)
                Next
            End If
        End If
    End Sub
    Public Sub cargarComboMotivoDescarte()
        Dim mdes As New dMotivoDescarte
        Dim lista As New ArrayList
        lista = mdes.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each mdes In lista
                    ComboDescarte.Items.Add(mdes)
                Next
            End If
        End If
    End Sub
    Public Sub cargarComboInformacionRetorno()
        Dim ir As New dInformacionRetorno
        Dim lista As New ArrayList
        lista = ir.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each ir In lista
                    ComboRetorno.Items.Add(ir)
                Next
            End If
        End If
    End Sub
    Public Sub cargarComboAutorizacion()
        Dim a As New dAutorizacion
        Dim lista As New ArrayList
        lista = a.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each a In lista
                    ComboAutorizacion.Items.Add(a)
                Next
            End If
        End If
    End Sub
    Public Sub limpiar()
        TextId.Text = ""
        DateFecha.Value = Now()
        TextFicha.Text = ""
        TextIdProductor.Text = ""
        TextProductor.Text = ""
        ComboMuestra.Text = ""
        ComboMuestra.SelectedItem = Nothing
        TextCantidad.Text = ""
        ComboTipoInforme.Text = ""
        ComboTipoInforme.SelectedItem = Nothing
        ComboDescarte.Text = ""
        ComboDescarte.SelectedItem = Nothing
        TextValor.Text = ""
        ComboRetorno.Text = ""
        ComboRetorno.SelectedItem = Nothing
        ComboAutorizacion.Text = ""
        ComboAutorizacion.SelectedItem = Nothing
        TextObservaciones.Text = ""
        TextFicha.Focus()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim v As New FormBuscarCliente
        v.ShowDialog()
        If Not v.Cliente Is Nothing Then
            Dim cli As dCliente = v.Cliente
            TextIdProductor.Text = cli.ID
            TextProductor.Text = cli.NOMBRE
            ComboMuestra.Focus()
        End If
    End Sub

    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        'Dim id As Long = TextId.Text.Trim
        Dim fecha As Date = DateFecha.Value.ToString("yyyy-MM-dd")
        'If TextFicha.Text.Trim.Length = 0 Then MsgBox("No se ha ingresado el número de ficha", MsgBoxStyle.Exclamation, "Atención") : TextFicha.Focus() : Exit Sub
        Dim ficha As Long
        If TextFicha.Text.Trim.Length > 0 Then
            ficha = TextFicha.Text.Trim
        Else
            ficha = 0
        End If
        If TextIdProductor.Text.Trim.Length = 0 Then MsgBox("No se ha ingresado el número de productor", MsgBoxStyle.Exclamation, "Atención") : TextIdProductor.Focus() : Exit Sub
        Dim idproductor As Long = TextIdProductor.Text.Trim
        Dim muestra As dMuestras = CType(ComboMuestra.SelectedItem, dMuestras)
        If TextCantidad.Text.Trim.Length = 0 Then MsgBox("No se ha ingresado la cantidad de muestras", MsgBoxStyle.Exclamation, "Atención") : TextCantidad.Focus() : Exit Sub
        Dim cantidad As Integer = TextCantidad.Text.Trim
        Dim idtipoinforme As dTipoInforme = CType(ComboTipoInforme.SelectedItem, dTipoInforme)
        Dim motivodescarte As dMotivoDescarte = CType(ComboDescarte.SelectedItem, dMotivoDescarte)
        Dim valor As Double
        If TextValor.Text <> "" Then
            valor = TextValor.Text.Trim
        End If
        Dim informacionretorno As dInformacionRetorno = CType(ComboRetorno.SelectedItem, dInformacionRetorno)
        Dim autorizacion As dAutorizacion = CType(ComboAutorizacion.SelectedItem, dAutorizacion)
        Dim observaciones As String = TextObservaciones.Text.Trim
        If TextId.Text.Trim.Length > 0 Then
            Dim dm As New dDescarteMuestras()
            Dim id As Long = CType(TextId.Text.Trim, Long)
            Dim fec As String
            fec = Format(fecha, "yyyy-MM-dd")
            dm.ID = id
            dm.FECHA = fec
            dm.FICHA = ficha
            dm.IDPRODUCTOR = idproductor
            If Not muestra Is Nothing Then
                dm.IDMUESTRA = muestra.ID
            End If
            dm.CANTIDAD = cantidad
            If Not idtipoinforme Is Nothing Then
                dm.IDTIPOINFORME = idtipoinforme.ID
            End If
            If Not motivodescarte Is Nothing Then
                dm.IDMOTIVODESCARTE = motivodescarte.ID
            End If
            dm.VALOR = valor
            If Not informacionretorno Is Nothing Then
                dm.IDINFORETORNO = informacionretorno.ID
                If informacionretorno.ID = 2 Then
                    marcar_ficha_eliminada(ficha)
                End If
            End If
            If Not autorizacion Is Nothing Then
                dm.IDAUTORIZACION = autorizacion.ID
            End If
            dm.OBSERVACIONES = observaciones
            dm.OPERADOR = Usuario.ID
            If (dm.modificar(Usuario)) Then
                MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
                limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        Else
            If TextIdProductor.Text.Trim.Length > 0 Then
                Dim dm As New dDescarteMuestras()
                Dim sa As New dSolicitudAnalisis
                Dim fec As String
                fec = Format(fecha, "yyyy-MM-dd")
                dm.FECHA = fec
                dm.FICHA = ficha
                dm.IDPRODUCTOR = idproductor
                If Not muestra Is Nothing Then
                    dm.IDMUESTRA = muestra.ID
                End If
                dm.CANTIDAD = cantidad
                If Not idtipoinforme Is Nothing Then
                    dm.IDTIPOINFORME = idtipoinforme.ID
                End If
                If Not motivodescarte Is Nothing Then
                    dm.IDMOTIVODESCARTE = motivodescarte.ID
                End If
                dm.VALOR = valor
                If Not informacionretorno Is Nothing Then
                    dm.IDINFORETORNO = informacionretorno.ID
                End If
                If Not autorizacion Is Nothing Then
                    dm.IDAUTORIZACION = autorizacion.ID
                End If
                dm.OBSERVACIONES = observaciones
                dm.OPERADOR = Usuario.ID
                sa.ID = ficha
                If (dm.guardar(Usuario)) Then
                    If dm.IDINFORETORNO = 2 Then
                        sa.marcareliminado(Usuario)
                    Else

                    End If
                    MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
                    limpiar()
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If
        End If
    End Sub
    Private Sub marcar_ficha_eliminada(ByVal ficha As Long)
        Dim s As New dSolicitudAnalisis
        s.ID = ficha
        s.eliminar2(Usuario)
    End Sub
    Private Sub ButtonNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNuevo.Click
        limpiar()

    End Sub

    Private Sub ButtonBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBuscar.Click
        Dim v As New FormBuscarDescarte
        v.ShowDialog()
        If Not v.Descarte Is Nothing Then
            Dim des As dDescarteMuestras = v.Descarte
            TextId.Text = des.ID
            DateFecha.Value = des.FECHA
            TextFicha.Text = des.FICHA
            TextIdProductor.Text = des.IDPRODUCTOR
            Dim p As New dCliente
            p.ID = des.IDPRODUCTOR
            p = p.buscar
            TextProductor.Text = p.NOMBRE

            Dim m As New dMuestras
            For Each m In ComboMuestra.Items
                If m.ID = des.IDMUESTRA Then
                    ComboMuestra.SelectedItem = m
                    Exit For
                End If
            Next
            TextCantidad.Text = des.CANTIDAD

            Dim ti As New dTipoInforme
            For Each ti In ComboTipoInforme.Items
                If ti.ID = des.IDTIPOINFORME Then
                    ComboTipoInforme.SelectedItem = ti
                    Exit For
                End If
            Next
            Dim md As New dMotivoDescarte
            For Each md In ComboDescarte.Items
                If md.ID = des.IDMOTIVODESCARTE Then
                    ComboDescarte.SelectedItem = md
                    Exit For
                End If
            Next
            TextValor.Text = des.VALOR
            Dim ir As New dInformacionRetorno
            For Each ir In ComboRetorno.Items
                If ir.ID = des.IDINFORETORNO Then
                    ComboRetorno.SelectedItem = ir
                    Exit For
                End If
            Next
            Dim au As New dAutorizacion
            For Each au In ComboAutorizacion.Items
                If au.ID = des.IDMOTIVODESCARTE Then
                    ComboAutorizacion.SelectedItem = au
                    Exit For
                End If
            Next
            TextObservaciones.Text = des.OBSERVACIONES
            'ButtonBuscar.Focus()
        End If
    End Sub
    Private Sub ComboTipoInforme_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboTipoInforme.SelectedIndexChanged
        cargarComboMuestras()
    End Sub
    Public Sub cargarComboMuestras()
        Dim m As New dMuestras
        Dim lista As New ArrayList
        Dim idtipoinforme As dTipoInforme = CType(ComboTipoInforme.SelectedItem, dTipoInforme)
        If Not idtipoinforme Is Nothing Then
            Dim texto As Integer = idtipoinforme.ID
            ComboMuestra.Items.Clear()
            lista = m.listarxinforme(texto)
            If Not lista Is Nothing Then
                If lista.Count > 0 Then
                    For Each m In lista
                        ComboMuestra.Items.Add(m)
                    Next
                End If
            End If
        End If
    End Sub

    Private Sub TextFicha_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextFicha.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            buscardatos()
        End If
    End Sub
    Private Sub buscardatos()
        Dim sa As New dSolicitudAnalisis
        Dim ficha As Long = 0
        If TextFicha.Text <> "" Then
            ficha = TextFicha.Text.Trim
        End If
        sa.ID = ficha
        sa = sa.buscar
        If Not sa Is Nothing Then
            Dim c As New dCliente
            c.ID = sa.IDPRODUCTOR
            c = c.buscar
            If Not c Is Nothing Then
                TextIdProductor.Text = c.ID
                TextProductor.Text = c.NOMBRE
            End If
            Dim ti As dTipoInforme
            For Each ti In ComboTipoInforme.Items
                If ti.ID = sa.IDTIPOINFORME Then
                    ComboTipoInforme.SelectedItem = ti
                    Exit For
                End If
            Next
            cargarComboMuestras()
        End If
    End Sub

    Private Sub TextFicha_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextFicha.LostFocus
        buscardatos()
    End Sub
   
    Private Sub TextFicha_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextFicha.TextChanged

    End Sub
End Class