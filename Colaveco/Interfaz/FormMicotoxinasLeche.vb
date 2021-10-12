Public Class FormMicotoxinasLeche
    Private _usuario As dUsuario
    Private idsol As Long


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
        listarfichas()
        limpiar()

    End Sub
#End Region
    Public Sub listarfichas()
        Dim m As New dMicotoxinasLeche
        Dim lista As New ArrayList
        lista = m.listarfichas
        ListFichas.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each m In lista
                    ListFichas().Items.Add(m)
                Next
            End If
        End If
    End Sub

    Private Sub ListFichas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        limpiar()
        If ListFichas.SelectedItems.Count = 1 Then
            Dim m As New dMicotoxinasLeche
            Dim m2 As dMicotoxinasLeche = CType(ListFichas.SelectedItem, dMicotoxinasLeche)
            Dim id As Long = m2.FICHA
            Dim lista As New ArrayList
            lista = m2.listarporid(id)
            m.FICHA = m2.FICHA
            m = m.buscar
            If m.FECHA <> "00:00:00" Then
                DateFecha.Value = m.FECHA
            End If
            ListMuestras.Items.Clear()
            If Not lista Is Nothing Then
                If lista.Count > 0 Then
                    For Each m2 In lista
                        ListMuestras().Items.Add(m2)
                    Next
                End If
            End If
        End If
    End Sub

    Private Sub ListMuestras_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        limpiar()
        If ListMuestras.SelectedItems.Count = 1 Then
            Dim m As dMicotoxinasLeche = CType(ListMuestras.SelectedItem, dMicotoxinasLeche)
            TextId.Text = m.ID
            TextFicha.Text = m.FICHA
            DateFecha.Value = m.FECHA
            ComboOperador.Text = Usuario.NOMBRE
            TextMuestra.Text = m.MUESTRA
            If m.RESULTADO <> "-1" Then
                TextAflatoxina.Text = m.RESULTADO
            End If
            
            '********************************************

            Dim csm As New dCalidadSolicitudMuestra
            csm.FICHA = m.FICHA
            csm = csm.buscarxsolicitud
            Dim texto As String = ""
            If Not csm Is Nothing Then
                If csm.AFLATOXINA = 1 Then
                    texto = texto + "Aflatoxina M1"
                End If
                
            End If
            TextTipoInforme.Text = texto

            '*** HABILITAR CONTROLES *******************************
            If csm.AFLATOXINA = 1 Then
                TextAflatoxina.Enabled = True
            Else
                TextAflatoxina.Enabled = False
            End If

            '*******************************************************
        End If
    End Sub
    Private Sub limpiar()
        TextFicha.Text = ""
        DateFecha.Value = Now()
        TextMuestra.Text = ""
        TextAflatoxina.Text = ""
        TextTipoInforme.Text = ""
    End Sub

    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        guardar()
        listarproductos()
    End Sub
    Private Sub guardar()
        Dim ficha As Long = TextFicha.Text.Trim
        Dim fecha As Date = DateFecha.Value.ToString("yyyy-MM-dd")
        Dim fec As String
        fec = Format(fecha, "yyyy-MM-dd")
        If TextMuestra.Text.Trim.Length = 0 Then MsgBox("No se ha ingresado la muestra", MsgBoxStyle.Exclamation, "Atención") : TextMuestra.Focus() : Exit Sub
        Dim muestra As String = TextMuestra.Text.Trim
        Dim resultado As String = ""
        If TextAflatoxina.Text <> "" Then
            resultado = TextAflatoxina.Text.Trim
        Else
            resultado = -1
        End If
        
        Dim operador As Integer = Usuario.ID
        If TextId.Text.Trim.Length > 0 Then
            Dim m As New dMicotoxinasLeche
            Dim id As Long = CType(TextId.Text.Trim, Long)
            m.ID = id
            m.FICHA = ficha
            m.FECHA = fec
            m.MUESTRA = muestra
            m.RESULTADO = resultado
            m.OPERADOR = operador
            m.MARCA = 1
            If (m.modificar(Usuario)) Then
                MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
                idsol = ficha
                limpiar()
                listarfichas()
                ListMuestras.Items.Clear()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        Else
            Dim m As New dMicotoxinasLeche

            m.FICHA = ficha
            m.FECHA = fec
            m.MUESTRA = muestra
            m.RESULTADO = resultado
            m.OPERADOR = operador
            m.MARCA = 0
            If (m.guardar(Usuario)) Then
                MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
                idsol = ficha
                limpiar()
                listarfichas()
                ListMuestras.Items.Clear()
                'listaragua()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
    End Sub
    Public Sub listarproductos()
        limpiar()
        If ListFichas.SelectedItems.Count = 1 Then
            Dim m As dMicotoxinasLeche = CType(ListFichas.SelectedItem, dMicotoxinasLeche)
            Dim id As Long = m.FICHA
            idsol = id
            Dim lista As New ArrayList
            lista = m.listarporsolicitud(id)
            ListMuestras.Items.Clear()
            If Not lista Is Nothing Then
                If lista.Count > 0 Then
                    For Each m In lista
                        ListMuestras().Items.Add(m)
                    Next
                End If
            End If
        End If
    End Sub

    Private Sub ListFichas_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListFichas.SelectedIndexChanged
        limpiar()
        If ListFichas.SelectedItems.Count = 1 Then
            Dim a As New dMicotoxinasLeche
            Dim a2 As dMicotoxinasLeche = CType(ListFichas.SelectedItem, dMicotoxinasLeche)
            Dim id As Long = a2.FICHA
            idsol = a2.FICHA
            Dim lista As New ArrayList
            lista = a2.listarporid(id)
            a.FICHA = a2.FICHA
            a = a.buscar
            If a.FECHA <> "00:00:00" Then
                DateFechaProceso.Value = a.FECHA
            End If
            ListMuestras.Items.Clear()
            If Not lista Is Nothing Then
                If lista.Count > 0 Then
                    For Each a2 In lista
                        ListMuestras().Items.Add(a2)
                    Next
                End If
            End If
        End If
    End Sub

    Private Sub ListMuestras_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListMuestras.SelectedIndexChanged
        limpiar()
        If ListMuestras.SelectedItems.Count = 1 Then
            Dim a As dMicotoxinasLeche = CType(ListMuestras.SelectedItem, dMicotoxinasLeche)
            TextId.Text = a.ID
            TextFicha.Text = a.FICHA
            DateFecha.Value = a.FECHA
            ComboOperador.Text = Usuario.NOMBRE
            TextMuestra.Text = a.MUESTRA
            If a.RESULTADO <> "" Then
                TextAflatoxina.Text = a.RESULTADO
            End If
            
            '********************************************

            Dim csm As New dCalidadSolicitudMuestra
            csm.FICHA = a.FICHA
            csm = csm.buscar
            Dim texto As String = ""
            If Not csm Is Nothing Then
                If csm.AFLATOXINA = 1 Then
                    texto = texto + "Aflatoxina M1 "
                End If
            End If
            TextTipoInforme.Text = texto

            '*** HABILITAR CONTROLES *******************************
            If csm.AFLATOXINA = 1 Then
                TextAflatoxina.Enabled = True
            Else
                TextAflatoxina.Enabled = False
            End If

            '*******************************************************
        End If
    End Sub

    Private Sub ButtonGuardar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        guardar()
    End Sub
   
End Class