Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Public Class FormAntibiogramas
    Private _usuario As dUsuario
    Dim idsol As Long

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
        'listoantibiogramas()
        'listarantibiogramas()
        listarfichas()
        cargarComboMOA24()
        cargarComboMOA48()
        cargarComboResultados()
        cargarComboTipo()
        cargarComboTratado()
        ocultocombos()
        'cargarComboTratamiento()
        'cargarMatrizDeColumnas()
        'limpiar()

    End Sub
#End Region
    Public Sub listarantibiogramas()
        limpiar()
        If ListFichas.SelectedItems.Count = 1 Then
            Dim a As dAntibiograma = CType(ListFichas.SelectedItem, dAntibiograma)
            Dim id As Long = a.IDSOLICITUD
            idsol = id
            'a.listarporsolicitud(id)

            'Dim a As New dAntibiograma
            Dim lista As New ArrayList
            lista = a.listarporsolicitud(id)
            ListAntibiogramas.Items.Clear()
            If Not lista Is Nothing Then
                If lista.Count > 0 Then
                    For Each a In lista
                        ListAntibiogramas().Items.Add(a)
                    Next
                End If
            End If
        End If
        If ListAntibiogramas.Items.Count = 0 Then
            creainformeexcel()
            listarfichas()
        End If
    End Sub
    Public Sub listarfichas()
        Dim a As New dAntibiograma
        Dim lista As New ArrayList
        lista = a.listarfichas
        ListFichas.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each a In lista
                    ListFichas().Items.Add(a)
                Next
            End If
        End If
    End Sub

    Private Sub ListAntibiogramas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListAntibiogramas.SelectedIndexChanged
        limpiar()
        If ListAntibiogramas.SelectedItems.Count = 1 Then
            Dim a As dAntibiograma = CType(ListAntibiogramas.SelectedItem, dAntibiograma)
            TextId.Text = a.ID
            TextFicha.Text = a.IDSOLICITUD
            DateFechaSolicitud.Value = a.FECHASOLICITUD
            ComboOperador.Text = Usuario.NOMBRE
            TextIdAnimal.Text = a.IDANIMAL
        End If
        'listarantibiogramas()
    End Sub
    Private Sub limpiar()
        TextFicha.Text = ""
        DateFechaSolicitud.Value = Now()
        TextIdAnimal.Text = ""
        ComboTratado.Text = ""
        ComboTratado.SelectedItem = Nothing
        ComboMOA24.Text = ""
        ComboMOA24.SelectedItem = Nothing
        ComboMOA48.Text = ""
        ComboMOA48.SelectedItem = Nothing
        TextRC.Text = ""
        ComboTipo.Text = ""
        ComboTipo.SelectedItem = Nothing
        ComboP.Text = ""
        ComboP.SelectedItem = Nothing
        ComboCF.Text = ""
        ComboCF.SelectedItem = Nothing
        ComboOX.Text = ""
        ComboOX.SelectedItem = Nothing
        ComboSXT.Text = ""
        ComboSXT.SelectedItem = Nothing
        ComboAMC.Text = ""
        ComboAMC.SelectedItem = Nothing
        ComboRA.Text = ""
        ComboRA.SelectedItem = Nothing
        ComboE.Text = ""
        ComboE.SelectedItem = Nothing
        ComboT.Text = ""
        ComboT.SelectedItem = Nothing
        ComboENO.Text = ""
        ComboENO.SelectedItem = Nothing
        ComboGM.Text = ""
        ComboGM.SelectedItem = Nothing
        ComboAM.Text = ""
        ComboAM.SelectedItem = Nothing
        ocultocombos()
        'listarantibiogramas()
    End Sub
    Private Sub limpiar2()
        'TextFicha.Text = ""
        'DateFechaSolicitud.Value = Now()
        'TextIdAnimal.Text = ""
        ComboTratado.Text = ""
        ComboTratado.SelectedItem = Nothing
        ComboMOA24.Text = ""
        ComboMOA24.SelectedItem = Nothing
        ComboMOA48.Text = ""
        ComboMOA48.SelectedItem = Nothing
        'TextRC.Text = ""
        ComboTipo.Text = ""
        ComboTipo.SelectedItem = Nothing
        ComboP.Text = ""
        ComboP.SelectedItem = Nothing
        ComboCF.Text = ""
        ComboCF.SelectedItem = Nothing
        ComboOX.Text = ""
        ComboOX.SelectedItem = Nothing
        ComboSXT.Text = ""
        ComboSXT.SelectedItem = Nothing
        ComboAMC.Text = ""
        ComboAMC.SelectedItem = Nothing
        ComboRA.Text = ""
        ComboRA.SelectedItem = Nothing
        ComboE.Text = ""
        ComboE.SelectedItem = Nothing
        ComboT.Text = ""
        ComboT.SelectedItem = Nothing
        ComboENO.Text = ""
        ComboENO.SelectedItem = Nothing
        ComboGM.Text = ""
        ComboGM.SelectedItem = Nothing
        ComboAM.Text = ""
        ComboAM.SelectedItem = Nothing
        TextId.Text = ""
        ocultocombos()
        'listarantibiogramas()
    End Sub
    Public Sub cargarComboResultados()
        Dim ra As New dResultadoAntibiograma
        Dim lista As New ArrayList
        lista = ra.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each ra In lista
                    ComboP.Items.Add(ra)
                    ComboE.Items.Add(ra)
                    ComboCF.Items.Add(ra)
                    ComboRA.Items.Add(ra)
                    ComboSXT.Items.Add(ra)
                    ComboT.Items.Add(ra)
                    ComboOX.Items.Add(ra)
                    ComboAMC.Items.Add(ra)
                    ComboENO.Items.Add(ra)
                    ComboGM.Items.Add(ra)
                    ComboAM.Items.Add(ra)
                Next
            End If
        End If
    End Sub
    Public Sub cargarComboTipo()
        Dim ta As New dTipoAntibiograma
        Dim lista As New ArrayList
        lista = ta.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each ta In lista
                    ComboTipo.Items.Add(ta)
                Next
            End If
        End If
    End Sub
    Public Sub cargarComboMOA24()
        Dim m24 As New dMOA24
        Dim lista As New ArrayList
        lista = m24.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each m24 In lista
                    ComboMOA24.Items.Add(m24)
                Next
            End If
        End If
    End Sub
    Public Sub cargarComboMOA48()
        Dim m48 As New dMOA48
        Dim lista As New ArrayList
        lista = m48.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each m48 In lista
                    ComboMOA48.Items.Add(m48)
                Next
            End If
        End If
    End Sub
    Public Sub cargarComboTratado()
        ComboTratado.Items.Add("Si")
        ComboTratado.Items.Add("No")
    End Sub

    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        guardar()
        limpiar()

    End Sub
    Private Sub guardar()
        Dim idsolicitud As Long = TextFicha.Text.Trim
        Dim fechasolicitud As Date = DateFechaSolicitud.Value.ToString("yyyy-MM-dd")
        Dim fecsol As String
        fecsol = Format(fechasolicitud, "yyyy-MM-dd")
        'Dim fechaproceso As Date = Now()
        'Dim fecpro As String
        'fecpro = Format(fechaproceso, "yyyy-MM-dd")
        Dim fechaproceso As Date = DateFechaProceso.Value.ToString("yyyy-MM-dd")
        Dim fechapro As String
        fechapro = Format(fechaproceso, "yyyy-MM-dd")
        If TextIdAnimal.Text.Trim.Length = 0 Then MsgBox("No se ha ingresado el id animal", MsgBoxStyle.Exclamation, "Atención") : TextIdAnimal.Focus() : Exit Sub
        Dim idanimal As String = TextIdAnimal.Text.Trim
        Dim tratado As Integer
        If ComboTratado.Text = "Si" Then
            tratado = 1
        ElseIf ComboTratado.Text = "No" Then
            tratado = 0
        End If
        Dim idmicroorgaislado24 As dMOA24 = CType(ComboMOA24.SelectedItem, dMOA24)
        Dim idmicroorgaislado48 As dMOA48 = CType(ComboMOA48.SelectedItem, dMOA48)
        Dim rc As Integer
        If TextRC.Text <> "" Then
            rc = TextRC.Text.Trim
        End If
        Dim idtipo As dTipoAntibiograma = CType(ComboTipo.SelectedItem, dTipoAntibiograma)
        Dim p As dResultadoAntibiograma = CType(ComboP.SelectedItem, dResultadoAntibiograma)
        Dim cf As dResultadoAntibiograma = CType(ComboCF.SelectedItem, dResultadoAntibiograma)
        Dim ox As dResultadoAntibiograma = CType(ComboOX.SelectedItem, dResultadoAntibiograma)
        Dim sxt As dResultadoAntibiograma = CType(ComboSXT.SelectedItem, dResultadoAntibiograma)
        Dim amc As dResultadoAntibiograma = CType(ComboAMC.SelectedItem, dResultadoAntibiograma)
        Dim ra As dResultadoAntibiograma = CType(ComboRA.SelectedItem, dResultadoAntibiograma)
        Dim er As dResultadoAntibiograma = CType(ComboE.SelectedItem, dResultadoAntibiograma)
        Dim t As dResultadoAntibiograma = CType(ComboT.SelectedItem, dResultadoAntibiograma)
        Dim eno As dResultadoAntibiograma = CType(ComboENO.SelectedItem, dResultadoAntibiograma)
        Dim gm As dResultadoAntibiograma = CType(ComboGM.SelectedItem, dResultadoAntibiograma)
        Dim am As dResultadoAntibiograma = CType(ComboAM.SelectedItem, dResultadoAntibiograma)
        Dim operador As Integer = Usuario.ID
        If TextId.Text.Trim.Length > 0 Then
            'If TextIdAnimal.Text.Trim.Length > 0 Then
            Dim a As New dAntibiograma()
           
            Dim id As Long = CType(TextId.Text.Trim, Long)
            a.ID = id
            a.IDSOLICITUD = idsolicitud
            a.FECHASOLICITUD = fecsol
            a.FECHAPROCESO = fechapro
            a.IDANIMAL = idanimal
            a.TRATADO = tratado
            If Not idmicroorgaislado24 Is Nothing Then
                a.IDMICROORGAISLADO24 = idmicroorgaislado24.ID
            End If
            If Not idmicroorgaislado48 Is Nothing Then
                a.IDMICROORGAISLADO48 = idmicroorgaislado48.ID
                a.COMBO = 0
            End If
            a.RC = rc
            If Not idtipo Is Nothing Then
                a.IDTIPO = idtipo.ID
            Else
                a.IDTIPO = 1
            End If
            Dim a2 As New dAntibiograma2
            a2.IDSOLICITUD = Val(TextFicha.Text.Trim)
            a2 = a2.buscar

            If a2.ANTIBIOGRAMA = 1 Then
                If Not idmicroorgaislado24 Is Nothing Then
                    If idmicroorgaislado24.ID = 1 Or idmicroorgaislado24.ID = 2 Or idmicroorgaislado24.ID = 6 Or idmicroorgaislado24.ID = 7 Or idmicroorgaislado24.ID = 10 Or idmicroorgaislado24.ID = 11 Then
                        a.COMBO = 0
                    ElseIf idmicroorgaislado24.ID = 3 Or idmicroorgaislado24.ID = 8 Or idmicroorgaislado24.ID = 12 Or idmicroorgaislado24.ID = 15 Then
                        a.COMBO = 1
                    ElseIf idmicroorgaislado24.ID = 4 Or idmicroorgaislado24.ID = 5 Then
                        a.COMBO = 2
                    ElseIf idmicroorgaislado24.ID = 9 Or idmicroorgaislado24.ID = 13 Or idmicroorgaislado24.ID = 14 Or idmicroorgaislado24.ID = 16 Or idmicroorgaislado24.ID = 17 Or idmicroorgaislado24.ID = 18 Then
                        a.COMBO = 3
                    End If
                End If
            Else
                a.COMBO = 0
            End If
            If Not p Is Nothing Then
                a.P = p.ID
            End If
            If Not cf Is Nothing Then
                a.CF = cf.ID
            End If
            If Not ox Is Nothing Then
                a.OX = ox.ID
            End If
            If Not sxt Is Nothing Then
                a.SXT = sxt.ID
            End If
            If Not amc Is Nothing Then
                a.AMC = amc.ID
            End If
            If Not ra Is Nothing Then
                a.RA = ra.ID
            End If
            If Not er Is Nothing Then
                a.E = er.ID
            End If
            If Not t Is Nothing Then
                a.T = t.ID
            End If
            If Not eno Is Nothing Then
                a.ENO = eno.ID
            End If
            If Not gm Is Nothing Then
                a.GM = gm.ID
            End If
            If Not am Is Nothing Then
                a.AM = am.ID
            End If
            a.OPERADOR = operador
            a.MARCA = 1
            If (a.modificar(Usuario)) Then
                MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
                listarantibiogramas()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        Else
            Dim a As New dAntibiograma()
            'Dim id As Long = CType(TextId.Text.Trim, Long)
            'a.ID = id
            a.IDSOLICITUD = idsolicitud
            a.FECHASOLICITUD = fecsol
            a.FECHAPROCESO = fechapro
            a.IDANIMAL = idanimal
            a.TRATADO = tratado
            If Not idmicroorgaislado24 Is Nothing Then
                a.IDMICROORGAISLADO24 = idmicroorgaislado24.ID
            End If
            If Not idmicroorgaislado48 Is Nothing Then
                a.IDMICROORGAISLADO48 = idmicroorgaislado48.ID
            End If
            a.RC = rc
            If Not idtipo Is Nothing Then
                a.IDTIPO = idtipo.ID
            End If
            If idmicroorgaislado24.ID = 1 Or idmicroorgaislado24.ID = 2 Or idmicroorgaislado24.ID = 6 Or idmicroorgaislado24.ID = 7 Or idmicroorgaislado24.ID = 10 Or idmicroorgaislado24.ID = 11 Then
                a.COMBO = 0
            ElseIf idmicroorgaislado24.ID = 3 Or idmicroorgaislado24.ID = 8 Or idmicroorgaislado24.ID = 12 Or idmicroorgaislado24.ID = 15 Then
                a.COMBO = 1
            ElseIf idmicroorgaislado24.ID = 4 Or idmicroorgaislado24.ID = 5 Then
                a.COMBO = 2
            ElseIf idmicroorgaislado24.ID = 9 Or idmicroorgaislado24.ID = 13 Or idmicroorgaislado24.ID = 14 Or idmicroorgaislado24.ID = 16 Or idmicroorgaislado24.ID = 17 Or idmicroorgaislado24.ID = 18 Then
                a.COMBO = 3
            End If
            If Not p Is Nothing Then
                a.P = p.ID
            End If
            If Not cf Is Nothing Then
                a.CF = cf.ID
            End If
            If Not ox Is Nothing Then
                a.OX = ox.ID
            End If
            If Not sxt Is Nothing Then
                a.SXT = sxt.ID
            End If
            If Not amc Is Nothing Then
                a.AMC = amc.ID
            End If
            If Not ra Is Nothing Then
                a.RA = ra.ID
            End If
            If Not er Is Nothing Then
                a.E = er.ID
            End If
            If Not t Is Nothing Then
                a.T = t.ID
            End If
            If Not eno Is Nothing Then
                a.ENO = eno.ID
            End If
            If Not gm Is Nothing Then
                a.GM = gm.ID
            End If
            If Not am Is Nothing Then
                a.AM = am.ID
            End If
            a.OPERADOR = operador
            a.MARCA = 1
            If (a.guardar(Usuario)) Then
                MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
                listarantibiogramas()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
    End Sub
    Private Sub guardar2()
        Dim idsolicitud As Long = TextFicha.Text.Trim
        Dim fechasolicitud As Date = DateFechaSolicitud.Value.ToString("yyyy-MM-dd")
        Dim fecsol As String
        fecsol = Format(fechasolicitud, "yyyy-MM-dd")
        'Dim fechaproceso As Date = Now()
        'Dim fecpro As String
        'fecpro = Format(fechaproceso, "yyyy-MM-dd")
        Dim fechaproceso As Date = DateFechaProceso.Value.ToString("yyyy-MM-dd")
        Dim fechapro As String
        fechapro = Format(fechaproceso, "yyyy-MM-dd")
        If TextIdAnimal.Text.Trim.Length = 0 Then MsgBox("No se ha ingresado el id animal", MsgBoxStyle.Exclamation, "Atención") : TextIdAnimal.Focus() : Exit Sub
        Dim idanimal As String = TextIdAnimal.Text.Trim
        Dim tratado As Integer
        If ComboTratado.Text = "Si" Then
            tratado = 1
        ElseIf ComboTratado.Text = "No" Then
            tratado = 0
        End If
        Dim idmicroorgaislado24 As dMOA24 = CType(ComboMOA24.SelectedItem, dMOA24)
        Dim idmicroorgaislado48 As dMOA48 = CType(ComboMOA48.SelectedItem, dMOA48)
        Dim rc As Integer
        If TextRC.Text <> "" Then
            rc = TextRC.Text.Trim
        End If
        Dim idtipo As Integer
        If ComboTipo.Text = "Clínico" Then
            idtipo = 1
        ElseIf ComboTipo.Text = "Subclínico" Then
            idtipo = 2
        End If
        Dim p As dResultadoAntibiograma = CType(ComboP.SelectedItem, dResultadoAntibiograma)
        Dim cf As dResultadoAntibiograma = CType(ComboCF.SelectedItem, dResultadoAntibiograma)
        Dim ox As dResultadoAntibiograma = CType(ComboOX.SelectedItem, dResultadoAntibiograma)
        Dim sxt As dResultadoAntibiograma = CType(ComboSXT.SelectedItem, dResultadoAntibiograma)
        Dim amc As dResultadoAntibiograma = CType(ComboAMC.SelectedItem, dResultadoAntibiograma)
        Dim ra As dResultadoAntibiograma = CType(ComboRA.SelectedItem, dResultadoAntibiograma)
        Dim er As dResultadoAntibiograma = CType(ComboE.SelectedItem, dResultadoAntibiograma)
        Dim t As dResultadoAntibiograma = CType(ComboT.SelectedItem, dResultadoAntibiograma)
        Dim eno As dResultadoAntibiograma = CType(ComboENO.SelectedItem, dResultadoAntibiograma)
        Dim gm As dResultadoAntibiograma = CType(ComboGM.SelectedItem, dResultadoAntibiograma)
        Dim am As dResultadoAntibiograma = CType(ComboAM.SelectedItem, dResultadoAntibiograma)
        Dim operador As Integer = Usuario.ID
        If TextId.Text.Trim.Length > 0 Then
            'If TextIdAnimal.Text.Trim.Length > 0 Then
            Dim a As New dAntibiograma()
            Dim id As Long = CType(TextId.Text.Trim, Long)
            a.ID = id
            a.IDSOLICITUD = idsolicitud
            a.FECHASOLICITUD = fecsol
            a.FECHAPROCESO = fechapro
            a.IDANIMAL = idanimal
            a.TRATADO = tratado
            If Not idmicroorgaislado24 Is Nothing Then
                a.IDMICROORGAISLADO24 = idmicroorgaislado24.ID
            End If
            If Not idmicroorgaislado48 Is Nothing Then
                a.IDMICROORGAISLADO48 = idmicroorgaislado48.ID
            End If
            a.RC = rc
            a.IDTIPO = idtipo
            If idmicroorgaislado24.ID = 1 Or idmicroorgaislado24.ID = 2 Or idmicroorgaislado24.ID = 6 Or idmicroorgaislado24.ID = 7 Or idmicroorgaislado24.ID = 10 Or idmicroorgaislado24.ID = 11 Then
                a.COMBO = 0
            ElseIf idmicroorgaislado24.ID = 3 Or idmicroorgaislado24.ID = 8 Or idmicroorgaislado24.ID = 12 Or idmicroorgaislado24.ID = 15 Then
                a.COMBO = 1
            ElseIf idmicroorgaislado24.ID = 4 Or idmicroorgaislado24.ID = 5 Then
                a.COMBO = 2
            ElseIf idmicroorgaislado24.ID = 9 Or idmicroorgaislado24.ID = 13 Or idmicroorgaislado24.ID = 14 Or idmicroorgaislado24.ID = 16 Or idmicroorgaislado24.ID = 17 Or idmicroorgaislado24.ID = 18 Then
                a.COMBO = 3
            End If
            If Not p Is Nothing Then
                a.P = p.ID
            End If
            If Not cf Is Nothing Then
                a.CF = cf.ID
            End If
            If Not ox Is Nothing Then
                a.OX = ox.ID
            End If
            If Not sxt Is Nothing Then
                a.SXT = sxt.ID
            End If
            If Not amc Is Nothing Then
                a.AMC = amc.ID
            End If
            If Not ra Is Nothing Then
                a.RA = ra.ID
            End If
            If Not er Is Nothing Then
                a.E = er.ID
            End If
            If Not t Is Nothing Then
                a.T = t.ID
            End If
            If Not eno Is Nothing Then
                a.ENO = eno.ID
            End If
            If Not gm Is Nothing Then
                a.GM = gm.ID
            End If
            If Not am Is Nothing Then
                a.AM = am.ID
            End If
            a.OPERADOR = operador
            a.MARCA = 1
            If (a.modificar(Usuario)) Then
                MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
                'listarantibiogramas()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        Else
            Dim a As New dAntibiograma()
            'Dim id As Long = CType(TextId.Text.Trim, Long)
            'a.ID = id
            a.IDSOLICITUD = idsolicitud
            a.FECHASOLICITUD = fecsol
            a.FECHAPROCESO = fechapro
            a.IDANIMAL = idanimal
            a.TRATADO = tratado
            If Not idmicroorgaislado24 Is Nothing Then
                a.IDMICROORGAISLADO24 = idmicroorgaislado24.ID
            End If
            If Not idmicroorgaislado48 Is Nothing Then
                a.IDMICROORGAISLADO48 = idmicroorgaislado48.ID
            End If
            a.RC = rc
            a.IDTIPO = idtipo
            If idmicroorgaislado24.ID = 1 Or idmicroorgaislado24.ID = 2 Or idmicroorgaislado24.ID = 6 Or idmicroorgaislado24.ID = 7 Or idmicroorgaislado24.ID = 10 Or idmicroorgaislado24.ID = 11 Then
                a.COMBO = 0
            ElseIf idmicroorgaislado24.ID = 3 Or idmicroorgaislado24.ID = 8 Or idmicroorgaislado24.ID = 12 Or idmicroorgaislado24.ID = 15 Then
                a.COMBO = 1
            ElseIf idmicroorgaislado24.ID = 4 Or idmicroorgaislado24.ID = 5 Then
                a.COMBO = 2
            ElseIf idmicroorgaislado24.ID = 9 Or idmicroorgaislado24.ID = 13 Or idmicroorgaislado24.ID = 14 Or idmicroorgaislado24.ID = 16 Or idmicroorgaislado24.ID = 17 Or idmicroorgaislado24.ID = 18 Then
                a.COMBO = 3
            End If
            If Not p Is Nothing Then
                a.P = p.ID
            End If
            If Not cf Is Nothing Then
                a.CF = cf.ID
            End If
            If Not ox Is Nothing Then
                a.OX = ox.ID
            End If
            If Not sxt Is Nothing Then
                a.SXT = sxt.ID
            End If
            If Not amc Is Nothing Then
                a.AMC = amc.ID
            End If
            If Not ra Is Nothing Then
                a.RA = ra.ID
            End If
            If Not er Is Nothing Then
                a.E = er.ID
            End If
            If Not t Is Nothing Then
                a.T = t.ID
            End If
            If Not eno Is Nothing Then
                a.ENO = eno.ID
            End If
            If Not gm Is Nothing Then
                a.GM = gm.ID
            End If
            If Not am Is Nothing Then
                a.AM = am.ID
            End If
            a.OPERADOR = operador
            a.MARCA = 1
            If (a.guardar(Usuario)) Then
                MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
                'listarantibiogramas()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
    End Sub
    Private Sub ButtonAgregarAislamiento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAgregarAislamiento.Click
        guardar2()
        limpiar2()
    End Sub

    Private Sub ComboMOA24_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboMOA24.SelectedIndexChanged
        muestrocombos()
    End Sub
    Private Sub muestrocombos()
        If ListAntibiogramas.SelectedItems.Count = 1 Then
            Dim a2 As New dAntibiograma2()
            a2.IDSOLICITUD = Val(TextFicha.Text.Trim)
            a2 = a2.buscar

            If Not a2 Is Nothing Then
                If a2.ANTIBIOGRAMA = 1 Then


                    If Not ComboMOA24.SelectedItem Is Nothing Then
                        Dim idmicroorgaislado24 As dMOA24 = CType(ComboMOA24.SelectedItem, dMOA24)
                        Dim id As Integer = idmicroorgaislado24.ID
                        If id = 1 Or id = 2 Or id = 7 Or id = 6 Or id = 10 Or id = 11 Then
                            ocultocombos()
                        ElseIf id = 3 Or id = 8 Or id = 12 Or id = 15 Then
                            ComboP.Enabled = True
                            ComboE.Enabled = True
                            ComboCF.Enabled = True
                            ComboRA.Enabled = True
                            ComboSXT.Enabled = True
                            ComboT.Enabled = True
                            ComboOX.Enabled = True
                            ComboAMC.Enabled = True
                            ComboENO.Enabled = False
                            ComboGM.Enabled = False
                            ComboAM.Enabled = False
                        ElseIf id = 4 Or id = 5 Then
                            ComboP.Enabled = True
                            ComboE.Enabled = True
                            ComboCF.Enabled = True
                            ComboRA.Enabled = True
                            ComboSXT.Enabled = True
                            ComboT.Enabled = False
                            ComboOX.Enabled = False
                            ComboAMC.Enabled = True
                            ComboENO.Enabled = False
                            ComboGM.Enabled = False
                            ComboAM.Enabled = False
                        ElseIf id = 9 Or id = 16 Or id = 17 Or id = 18 Or id = 13 Or id = 14 Or id = 19 Or id = 20 Then
                            ComboP.Enabled = False
                            ComboE.Enabled = False
                            ComboCF.Enabled = False
                            ComboRA.Enabled = False
                            ComboSXT.Enabled = True
                            ComboT.Enabled = True
                            ComboOX.Enabled = False
                            ComboAMC.Enabled = True
                            ComboENO.Enabled = True
                            ComboGM.Enabled = True
                            ComboAM.Enabled = True
                        End If
                    End If
                Else
                    ocultocombos()
                End If
            End If
        End If
    End Sub
    Private Sub ocultocombos()
        ComboP.Enabled = False
        ComboE.Enabled = False
        ComboCF.Enabled = False
        ComboRA.Enabled = False
        ComboSXT.Enabled = False
        ComboT.Enabled = False
        ComboOX.Enabled = False
        ComboAMC.Enabled = False
        ComboENO.Enabled = False
        ComboGM.Enabled = False
        ComboAM.Enabled = False
    End Sub

    Private Sub ListFichas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListFichas.SelectedIndexChanged
        limpiar()
        If ListFichas.SelectedItems.Count = 1 Then
            Dim a As dAntibiograma = CType(ListFichas.SelectedItem, dAntibiograma)
            Dim id As Long = a.IDSOLICITUD
            'a.listarporsolicitud(id)

            'Dim a As New dAntibiograma
            Dim lista As New ArrayList
            lista = a.listarporsolicitud(id)
            ListAntibiogramas.Items.Clear()
            If Not lista Is Nothing Then
                If lista.Count > 0 Then
                    For Each a In lista
                        ListAntibiogramas().Items.Add(a)
                    Next
                End If
            End If

        End If
    End Sub
    Private Sub creainformeexcel()
        Dim x1app As Microsoft.Office.Interop.Excel.Application
        Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
        Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
        x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
        x1libro = CType(x1app.Workbooks.Add, Microsoft.Office.Interop.Excel.Workbook)
        x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)

        Dim a As New dAntibiograma
        'Dim moa24 As New dMOA24
        Dim sa As New dSolicitudAnalisis
        Dim pro As New dProductor
        Dim tec As New dTecnicos
        Dim a2 As New dAntibiograma2
        Dim tipant As New dTipoAntibiograma
        Dim lista As New ArrayList
        '*****************************
        'idsol = TextBox1.Text.Trim
        sa.ID = idsol
        sa = sa.buscar
        a2.IDSOLICITUD = idsol
        a2 = a2.buscar

        '*****************************
        x1hoja.Cells(8, 2).formula = sa.ID
        x1hoja.Cells(8, 2).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(8, 2).Font.Size = 9
        pro.ID = sa.IDPRODUCTOR
        pro = pro.buscar
        x1hoja.Cells(9, 2).formula = pro.NOMBRE
        x1hoja.Cells(9, 2).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(9, 2).Font.Size = 9
        x1hoja.Cells(10, 2).formula = pro.DIRECCION
        x1hoja.Cells(10, 2).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(10, 2).Font.Size = 9
        tec.ID = pro.TECNICO
        If tec.ID > 0 Then
            tec = tec.buscar
        End If
        If Not tec.NOMBRE Is Nothing Then
            x1hoja.Cells(11, 2).formula = tec.NOMBRE
        End If
        x1hoja.Cells(11, 2).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(11, 2).Font.Size = 9

        Dim fechaem As Date = Now()
        Dim fechaemi As String = fechaem.ToString("dd/MM/yyyy")


        lista = a.listarporsolicitud2(idsol)
        x1hoja.Range("H8", "J8").Merge()
        x1hoja.Cells(8, 8).formula = sa.FECHAINGRESO
        x1hoja.Cells(8, 8).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(8, 8).Font.Size = 9
        x1hoja.Range("H9", "L9").Merge()
        x1hoja.Cells(9, 8).formula = a.FECHAPROCESO
        x1hoja.Cells(9, 8).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(9, 8).Font.Size = 9
        x1hoja.Range("H10", "L10").Merge()
        x1hoja.Cells(10, 8).formula = fechaemi
        x1hoja.Cells(10, 8).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(10, 8).Font.Size = 9


        Dim fila As Integer
        Dim columna As Integer
        fila = 17
        columna = 1
        'ListAntibiogramas.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim controlcombo As Integer = 10
                Dim clinico As Integer
                Dim noclinico As Integer
                For Each a In lista

                    x1hoja.Cells(9, 8).formula = a.FECHAPROCESO
                    x1hoja.Cells(9, 8).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(9, 8).Font.Size = 9

                    tipant.ID = a.IDTIPO
                    tipant = tipant.buscar
                    If Not tipant.NOMBRE Is Nothing Then
                        x1hoja.Cells(12, 2).formula = tipant.NOMBRE
                    End If
                    x1hoja.Cells(12, 2).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(12, 2).Font.Size = 9

                    Dim ra As New dResultadoAntibiograma
                    Dim moa24 As New dMOA24
                    Dim moa48 As New dMOA48

                    If a.COMBO = 0 Then
                        If controlcombo <> a.COMBO Then
                            controlcombo = a.COMBO
                            fila = fila + 1
                        End If

                        'datos combo 0
                        x1hoja.Cells(fila, columna).formula = a.IDANIMAL
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        moa24.ID = a.IDMICROORGAISLADO24
                        If moa24.ID > 0 Then
                            moa24 = moa24.buscar
                            x1hoja.Cells(fila, columna).formula = moa24.NOMBRE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            columna = columna + 1


                            'If a.IDTIPO = 2 Then
                            If a.RC = 0 Then
                                x1hoja.Cells(fila, columna).formula = "Clínica"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                clinico = clinico + 1
                                columna = columna + 1
                            Else
                                x1hoja.Cells(fila, columna).formula = a.RC
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                noclinico = noclinico + 1
                                columna = columna + 1
                            End If
                            
                            columna = 1
                            fila = fila + 1
                        Else
                            columna = 1
                        End If
                        moa48.ID = a.IDMICROORGAISLADO48
                        If moa48.ID > 0 Then
                            x1hoja.Cells(fila, columna).formula = a.IDANIMAL
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            columna = columna + 1
                            moa48 = moa48.buscar
                            x1hoja.Cells(fila, columna).formula = moa48.NOMBRE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            columna = columna + 1
                            'If a.IDTIPO = 2 Then
                            If a.RC = 0 Then
                                x1hoja.Cells(fila, columna).formula = "Clínica"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                clinico = clinico + 1
                                columna = columna + 1
                            Else
                                x1hoja.Cells(fila, columna).formula = a.RC
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                noclinico = noclinico + 1
                                columna = columna + 1
                            End If
                            
                            columna = 1
                            fila = fila + 1
                        End If
                    ElseIf a.COMBO = 1 Then
                        'cabezal combo 1
                        If controlcombo <> a.COMBO Then
                            'fila = fila + 1
                            controlcombo = a.COMBO
                            If a2.ANTIBIOGRAMA <> 0 Then
                                x1hoja.Cells(fila, 4).Formula = "P"
                                x1hoja.Cells(fila, 4).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, 4).Font.Bold = True
                                x1hoja.Cells(fila, 4).Font.Size = 8
                                x1hoja.Cells(fila, 5).Formula = "E"
                                x1hoja.Cells(fila, 5).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, 5).Font.Bold = True
                                x1hoja.Cells(fila, 5).Font.Size = 8
                                x1hoja.Cells(fila, 6).Formula = "CF"
                                x1hoja.Cells(fila, 6).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, 6).Font.Bold = True
                                x1hoja.Cells(fila, 6).Font.Size = 8
                                x1hoja.Cells(fila, 7).Formula = "RA"
                                x1hoja.Cells(fila, 7).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, 7).Font.Bold = True
                                x1hoja.Cells(fila, 7).Font.Size = 8
                                x1hoja.Cells(fila, 8).Formula = "SXT"
                                x1hoja.Cells(fila, 8).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, 8).Font.Bold = True
                                x1hoja.Cells(fila, 8).Font.Size = 8
                                x1hoja.Cells(fila, 9).Formula = "T"
                                x1hoja.Cells(fila, 9).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, 9).Font.Bold = True
                                x1hoja.Cells(fila, 9).Font.Size = 8
                                x1hoja.Cells(fila, 10).Formula = "OX"
                                x1hoja.Cells(fila, 10).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, 10).Font.Bold = True
                                x1hoja.Cells(fila, 10).Font.Size = 8
                                x1hoja.Cells(fila, 11).Formula = "AMC"
                                x1hoja.Cells(fila, 11).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, 11).Font.Bold = True
                                x1hoja.Cells(fila, 11).Font.Size = 8
                                fila = fila + 1
                            End If
                        End If

                        'datos combo 1
                        x1hoja.Cells(fila, columna).formula = a.IDANIMAL
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        moa24.ID = a.IDMICROORGAISLADO24
                        If moa24.ID > 0 Then
                            moa24 = moa24.buscar
                            x1hoja.Cells(fila, columna).formula = moa24.NOMBRE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            columna = columna + 1
                        End If

                        'If a.IDTIPO = 2 Then
                        If a.RC = 0 Then
                            x1hoja.Cells(fila, columna).formula = "Clínica"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            clinico = clinico + 1
                            columna = columna + 1
                        Else
                            x1hoja.Cells(fila, columna).formula = a.RC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            noclinico = noclinico + 1
                            columna = columna + 1
                        End If
                        ra.ID = a.P
                        ra = ra.buscar
                        x1hoja.Cells(fila, columna).formula = ra.SIGLA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        ra.ID = a.E
                        ra = ra.buscar
                        x1hoja.Cells(fila, columna).formula = ra.SIGLA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        ra.ID = a.CF
                        ra = ra.buscar
                        x1hoja.Cells(fila, columna).formula = ra.SIGLA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        ra.ID = a.RA
                        ra = ra.buscar
                        x1hoja.Cells(fila, columna).formula = ra.SIGLA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        ra.ID = a.SXT
                        ra = ra.buscar
                        x1hoja.Cells(fila, columna).formula = ra.SIGLA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        ra.ID = a.T
                        ra = ra.buscar
                        x1hoja.Cells(fila, columna).formula = ra.SIGLA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        ra.ID = a.OX
                        ra = ra.buscar
                        x1hoja.Cells(fila, columna).formula = ra.SIGLA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        ra.ID = a.AMC
                        ra = ra.buscar
                        x1hoja.Cells(fila, columna).formula = ra.SIGLA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = 1
                        fila = fila + 1
                        moa48.ID = a.IDMICROORGAISLADO48
                        If moa48.ID > 0 Then
                            x1hoja.Cells(fila, columna).formula = a.IDANIMAL
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            columna = columna + 1
                            moa48 = moa48.buscar
                            x1hoja.Cells(fila, columna).formula = moa48.NOMBRE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            columna = columna + 1
                            'If a.IDTIPO = 2 Then
                            If a.RC = 0 Then
                                x1hoja.Cells(fila, columna).formula = "Clínica"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                clinico = clinico + 1
                                columna = columna + 1
                            Else
                                x1hoja.Cells(fila, columna).formula = a.RC
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                noclinico = noclinico + 1
                                columna = columna + 1
                            End If
                            'ra.ID = a.SXT
                            'ra = ra.buscar
                            x1hoja.Cells(fila, columna).formula = "-" 'ra.SIGLA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            columna = columna + 1
                            'ra.ID = a.T
                            'ra = ra.buscar
                            x1hoja.Cells(fila, columna).formula = "-" 'ra.SIGLA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            columna = columna + 1
                            'ra.ID = a.AMC
                            'ra = ra.buscar
                            x1hoja.Cells(fila, columna).formula = "-" 'ra.SIGLA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            columna = columna + 1
                            'ra.ID = a.ENO
                            'ra = ra.buscar
                            x1hoja.Cells(fila, columna).formula = "-" 'ra.SIGLA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            columna = columna + 1
                            'ra.ID = a.GM
                            'ra = ra.buscar
                            x1hoja.Cells(fila, columna).formula = "-" 'ra.SIGLA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            columna = columna + 1
                            'ra.ID = a.GM
                            'ra = ra.buscar
                            x1hoja.Cells(fila, columna).formula = "-" 'ra.SIGLA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            columna = columna + 1
                            'ra.ID = a.GM
                            'ra = ra.buscar
                            x1hoja.Cells(fila, columna).formula = "-" 'ra.SIGLA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            columna = columna + 1
                            'ra.ID = a.AM
                            'ra = ra.buscar
                            x1hoja.Cells(fila, columna).formula = "-" 'ra.SIGLA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            columna = 1
                            fila = fila + 1
                        End If
                    ElseIf a.COMBO = 2 Then
                        If controlcombo <> a.COMBO Then
                            'fila = fila + 1
                            controlcombo = a.COMBO
                            'cabezal combo 2
                            x1hoja.Cells(fila, 4).Formula = "P"
                            x1hoja.Cells(fila, 4).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, 4).Font.Bold = True
                            x1hoja.Cells(fila, 4).Font.Size = 8
                            x1hoja.Cells(fila, 5).Formula = "E"
                            x1hoja.Cells(fila, 5).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, 5).Font.Bold = True
                            x1hoja.Cells(fila, 5).Font.Size = 8
                            x1hoja.Cells(fila, 6).Formula = "CF"
                            x1hoja.Cells(fila, 6).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, 6).Font.Bold = True
                            x1hoja.Cells(fila, 6).Font.Size = 8
                            x1hoja.Cells(fila, 7).Formula = "RA"
                            x1hoja.Cells(fila, 7).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, 7).Font.Bold = True
                            x1hoja.Cells(fila, 7).Font.Size = 8
                            x1hoja.Cells(fila, 8).Formula = "SXT"
                            x1hoja.Cells(fila, 8).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, 8).Font.Bold = True
                            x1hoja.Cells(fila, 8).Font.Size = 8
                            x1hoja.Cells(fila, 9).Formula = "AMC"
                            x1hoja.Cells(fila, 9).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, 9).Font.Bold = True
                            x1hoja.Cells(fila, 9).Font.Size = 8
                            fila = fila + 1
                        End If

                        'datos combo 2
                        x1hoja.Cells(fila, columna).formula = a.IDANIMAL
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        moa24.ID = a.IDMICROORGAISLADO24
                        If moa24.ID > 0 Then
                            moa24 = moa24.buscar
                            x1hoja.Cells(fila, columna).formula = moa24.NOMBRE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            columna = columna + 1
                        End If

                        'If a.IDTIPO = 2 Then
                        If a.RC = 0 Then
                            x1hoja.Cells(fila, columna).formula = "Clínica"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            clinico = clinico + 1
                            columna = columna + 1
                        Else
                            x1hoja.Cells(fila, columna).formula = a.RC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            noclinico = noclinico + 1
                            columna = columna + 1
                        End If
                        ra.ID = a.P
                        ra = ra.buscar
                        x1hoja.Cells(fila, columna).formula = ra.SIGLA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        ra.ID = a.E
                        ra = ra.buscar
                        x1hoja.Cells(fila, columna).formula = ra.SIGLA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        ra.ID = a.CF
                        ra = ra.buscar
                        x1hoja.Cells(fila, columna).formula = ra.SIGLA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        ra.ID = a.RA
                        ra = ra.buscar
                        x1hoja.Cells(fila, columna).formula = ra.SIGLA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        ra.ID = a.SXT
                        ra = ra.buscar
                        x1hoja.Cells(fila, columna).formula = ra.SIGLA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        ra.ID = a.AMC
                        ra = ra.buscar
                        x1hoja.Cells(fila, columna).formula = ra.SIGLA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = 1
                        fila = fila + 1
                        moa48.ID = a.IDMICROORGAISLADO48
                        If moa48.ID > 0 Then
                            x1hoja.Cells(fila, columna).formula = a.IDANIMAL
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            columna = columna + 1
                            moa48 = moa48.buscar
                            x1hoja.Cells(fila, columna).formula = moa48.NOMBRE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            columna = columna + 1
                            'If a.IDTIPO = 2 Then
                            If a.RC = 0 Then
                                x1hoja.Cells(fila, columna).formula = "Clínica"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                clinico = clinico + 1
                                columna = columna + 1
                            Else
                                x1hoja.Cells(fila, columna).formula = a.RC
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                noclinico = noclinico + 1
                                columna = columna + 1
                            End If
                            'ra.ID = a.SXT
                            'ra = ra.buscar
                            x1hoja.Cells(fila, columna).formula = "-" 'ra.SIGLA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            columna = columna + 1
                            'ra.ID = a.T
                            'ra = ra.buscar
                            x1hoja.Cells(fila, columna).formula = "-" 'ra.SIGLA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            columna = columna + 1
                            'ra.ID = a.AMC
                            'ra = ra.buscar
                            x1hoja.Cells(fila, columna).formula = "-" 'ra.SIGLA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            columna = columna + 1
                            'ra.ID = a.ENO
                            'ra = ra.buscar
                            x1hoja.Cells(fila, columna).formula = "-" 'ra.SIGLA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            columna = columna + 1
                            'ra.ID = a.GM
                            'ra = ra.buscar
                            x1hoja.Cells(fila, columna).formula = "-" 'ra.SIGLA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            columna = columna + 1
                            'ra.ID = a.GM
                            'ra = ra.buscar
                            x1hoja.Cells(fila, columna).formula = "-" 'ra.SIGLA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            columna = columna + 1
                            'ra.ID = a.GM
                            'ra = ra.buscar
                            x1hoja.Cells(fila, columna).formula = "-" 'ra.SIGLA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            columna = columna + 1
                            'ra.ID = a.AM
                            'ra = ra.buscar
                            x1hoja.Cells(fila, columna).formula = "-" 'ra.SIGLA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            columna = 1
                            fila = fila + 1
                        End If
                    ElseIf a.COMBO = 3 Then
                        If controlcombo <> a.COMBO Then
                            'fila = fila + 1
                            controlcombo = a.COMBO
                            'cabezal combo 3
                            x1hoja.Cells(fila, 4).Formula = "SXT"
                            x1hoja.Cells(fila, 4).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, 4).Font.Bold = True
                            x1hoja.Cells(fila, 4).Font.Size = 8
                            x1hoja.Cells(fila, 5).Formula = "T"
                            x1hoja.Cells(fila, 5).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, 5).Font.Bold = True
                            x1hoja.Cells(fila, 5).Font.Size = 8
                            x1hoja.Cells(fila, 6).Formula = "AMC"
                            x1hoja.Cells(fila, 6).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, 6).Font.Bold = True
                            x1hoja.Cells(fila, 6).Font.Size = 8
                            x1hoja.Cells(fila, 7).Formula = "ENO"
                            x1hoja.Cells(fila, 7).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, 7).Font.Bold = True
                            x1hoja.Cells(fila, 7).Font.Size = 8
                            x1hoja.Cells(fila, 8).Formula = "GM"
                            x1hoja.Cells(fila, 8).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, 8).Font.Bold = True
                            x1hoja.Cells(fila, 8).Font.Size = 8
                            x1hoja.Cells(fila, 9).Formula = "AM"
                            x1hoja.Cells(fila, 9).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, 9).Font.Bold = True
                            x1hoja.Cells(fila, 9).Font.Size = 8
                            fila = fila + 1
                        End If

                        'datos combo 3
                        x1hoja.Cells(fila, columna).formula = a.IDANIMAL
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        moa24.ID = a.IDMICROORGAISLADO24
                        If moa24.ID > 0 Then
                            moa24 = moa24.buscar
                            x1hoja.Cells(fila, columna).formula = moa24.NOMBRE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            columna = columna + 1
                        End If

                        'If a.IDTIPO = 2 Then
                        If a.RC = 0 Then
                            x1hoja.Cells(fila, columna).formula = "Clínica"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            clinico = clinico + 1
                            columna = columna + 1
                        Else
                            x1hoja.Cells(fila, columna).formula = a.RC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            noclinico = noclinico + 1
                            columna = columna + 1
                        End If
                        ra.ID = a.SXT
                        ra = ra.buscar
                        x1hoja.Cells(fila, columna).formula = ra.SIGLA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        ra.ID = a.T
                        ra = ra.buscar
                        x1hoja.Cells(fila, columna).formula = ra.SIGLA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        ra.ID = a.AMC
                        ra = ra.buscar
                        x1hoja.Cells(fila, columna).formula = ra.SIGLA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        ra.ID = a.ENO
                        ra = ra.buscar
                        x1hoja.Cells(fila, columna).formula = ra.SIGLA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        ra.ID = a.GM
                        ra = ra.buscar
                        x1hoja.Cells(fila, columna).formula = ra.SIGLA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = columna + 1
                        ra.ID = a.AM
                        ra = ra.buscar
                        x1hoja.Cells(fila, columna).formula = ra.SIGLA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        columna = 1
                        fila = fila + 1
                        moa48.ID = a.IDMICROORGAISLADO48
                        If moa48.ID > 0 Then
                            x1hoja.Cells(fila, columna).formula = a.IDANIMAL
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            columna = columna + 1
                            moa48 = moa48.buscar
                            x1hoja.Cells(fila, columna).formula = moa48.NOMBRE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            columna = columna + 1
                            'If a.IDTIPO = 2 Then
                            If a.RC = 0 Then
                                x1hoja.Cells(fila, columna).formula = "Clínica"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                clinico = clinico + 1
                                columna = columna + 1
                            Else
                                x1hoja.Cells(fila, columna).formula = a.RC
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                                noclinico = noclinico + 1
                                columna = columna + 1
                            End If
                            'ra.ID = a.SXT
                            'ra = ra.buscar
                            x1hoja.Cells(fila, columna).formula = "-" 'ra.SIGLA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            columna = columna + 1
                            'ra.ID = a.T
                            'ra = ra.buscar
                            x1hoja.Cells(fila, columna).formula = "-" 'ra.SIGLA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            columna = columna + 1
                            'ra.ID = a.AMC
                            'ra = ra.buscar
                            x1hoja.Cells(fila, columna).formula = "-" 'ra.SIGLA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            columna = columna + 1
                            'ra.ID = a.ENO
                            'ra = ra.buscar
                            x1hoja.Cells(fila, columna).formula = "-" 'ra.SIGLA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            columna = columna + 1
                            'ra.ID = a.GM
                            'ra = ra.buscar
                            x1hoja.Cells(fila, columna).formula = "-" 'ra.SIGLA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            columna = columna + 1
                            'ra.ID = a.GM
                            'ra = ra.buscar
                            x1hoja.Cells(fila, columna).formula = "-" 'ra.SIGLA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            columna = columna + 1
                            'ra.ID = a.GM
                            'ra = ra.buscar
                            x1hoja.Cells(fila, columna).formula = "-" 'ra.SIGLA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            columna = columna + 1
                            'ra.ID = a.AM
                            'ra = ra.buscar
                            x1hoja.Cells(fila, columna).formula = "-" 'ra.SIGLA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            columna = 1
                            fila = fila + 1
                        End If
                    End If
                Next
                'Referencias
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "Referencias:"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 8
                x1hoja.Cells(fila, columna).Font.Bold = True
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "Am: Ampicilina / Amc: Amoxicilina + Ác. Clavulánico / Cf: Cefalotina (cefalonium, cefacetrile)"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 8
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "E: Eritromicina (espiramicina, tilosina) / Eno: Enrofloxacina / Gm: Gentamicina / Ox: Cloxacilina (nafcilina)"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 8
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "P: Penicilina (ampicilina, amoxycilina) / Ra: Rifampin / Sxt: Trimetoprim sulfametoxazol (y otras sulfas) / T: Oxytetraciclina"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 8
                fila = fila + 1
                x1libro.Worksheets(1).cells(fila, columna).select()
                x1libro.ActiveSheet.pictures.Insert("c:\Debug\dario.jpg").select()
                fila = fila + 5
                x1hoja.Cells(fila, columna).formula = "Nota:"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 8
                If sa.OBSERVACIONES <> "" Then
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = sa.OBSERVACIONES
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = 1
                End If
                fila = fila + 2
                '******* CALCULO PRECIO ************************************************************************

                Dim ant As New dAntibiograma
                Dim ant2 As New dAntibiograma2
                Dim listamuestras As New ArrayList
                Dim listaaislamientos As New ArrayList
                Dim contadorantibiogramas As Integer = 0
                Dim contadoraislamientos As Integer = 0
                Dim muestraanterior As String = ""
                Dim marcaaislamiento As Integer = 0
                Dim total As Integer = 0

                Dim ana As New dAnalisis
                Dim idloteantibiograma As Integer = 85
                Dim idaislamiento As Integer = 11
                Dim idantibiograma As Integer = 12
                Dim idtimbre As Integer = 86
                Dim preciolote As Double = 0
                Dim precioaislamiento As Double = 0
                Dim precioantibiograma As Double = 0
                Dim preciotimbre As Double = 0
                Dim cantaislamientos As Integer = 0

                ant2.IDSOLICITUD = idsol
                ant2 = ant2.buscar()
                If ant2.ANTIBIOGRAMA = 0 Then
                    listaaislamientos = ant.listaraislamientos(idsol)
                    If Not listaaislamientos Is Nothing Then
                        If listaaislamientos.Count > 0 Then
                            cantaislamientos = listaaislamientos.Count
                        End If
                    End If
                    ana.ID = idaislamiento
                    ana = ana.buscar
                    precioaislamiento = ana.COSTO
                    total = cantaislamientos * precioaislamiento
                    ana.ID = idtimbre
                    ana = ana.buscar
                    preciotimbre = ana.COSTO
                    total = total + preciotimbre
                Else
                    listamuestras = ant.listarpormuestra(idsol)
                    If Not listamuestras Is Nothing Then
                        If listamuestras.Count > 0 Then
                            For Each ant In listamuestras
                                If muestraanterior <> ant.IDANIMAL Then
                                    If ant.COMBO = 0 Then
                                        contadoraislamientos = contadoraislamientos + 1
                                        marcaaislamiento = 1
                                    Else
                                        contadorantibiogramas = contadorantibiogramas + 1
                                    End If
                                    muestraanterior = ant.IDANIMAL
                                Else
                                    If ant.COMBO = 0 Then
                                        If marcaaislamiento = 1 Then

                                        Else
                                            contadoraislamientos = contadoraislamientos - 1
                                            contadorantibiogramas = contadorantibiogramas + 1
                                        End If
                                    Else
                                        contadoraislamientos = contadoraislamientos - 1
                                        contadorantibiogramas = contadorantibiogramas + 1
                                    End If
                                End If
                            Next
                        End If
                    End If
                    Dim contadortotal As Integer = 0
                    contadortotal = contadoraislamientos + contadorantibiogramas
                    Dim loteantibiograma As Integer
                    Dim antibiogramaindividual As Integer


                    If contadorantibiogramas Mod 5 = 0 Then
                        loteantibiograma = contadorantibiogramas / 5
                    Else
                        If contadorantibiogramas Mod 6 = 0 Then
                            loteantibiograma = contadorantibiogramas / 6
                        Else
                            loteantibiograma = contadorantibiogramas / 6
                            antibiogramaindividual = contadorantibiogramas Mod 6
                            If loteantibiograma = 0 And antibiogramaindividual = 0 Then
                                antibiogramaindividual = contadorantibiogramas
                            End If
                        End If
                    End If


                    ana.ID = idaislamiento
                    ana = ana.buscar
                    precioaislamiento = ana.COSTO
                    If ant.IDTIPO = 1 Or ant.IDTIPO = 2 Then
                        ana.ID = idantibiograma
                        ana = ana.buscar
                        precioantibiograma = ana.COSTO
                    Else
                        idantibiograma = 13
                        ana.ID = idantibiograma
                        ana = ana.buscar
                        precioantibiograma = ana.COSTO
                    End If
                    ana.ID = idloteantibiograma
                    ana = ana.buscar
                    preciolote = ana.COSTO
                    ana.ID = idtimbre
                    ana = ana.buscar
                    preciotimbre = ana.COSTO
                    Dim promedio As Double = 0
                    If antibiogramaindividual = 5 Then
                        total = (contadoraislamientos * precioaislamiento) + (loteantibiograma * preciolote) + (preciolote) + (preciotimbre)
                    Else
                        total = (contadoraislamientos * precioaislamiento) + (loteantibiograma * preciolote) + (antibiogramaindividual * precioantibiograma) + (preciotimbre)
                    End If
                    'If contadortotal >= 10 Then
                    'total = 0
                    'promedio = preciolote / 5
                    'total = (contadortotal * promedio) + preciotimbre
                    'End If
                    'If loteantibiograma >= 2 And antibiogramaindividual > 0 Then
                    'total = 0
                    'promedio = preciolote / 6
                    'total = (loteantibiograma * preciolote) + (promedio * antibiogramaindividual) + preciotimbre
                    'End If
                End If


                '***********************************************************************************************
                x1hoja.Cells(fila, columna).formula = "Por concepto de análisis: $" & " " & total & " (Timbre incluído)"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 8
                x1hoja.Cells(fila, columna).Font.Bold = True
                columna = columna + 3
                x1hoja.Cells(fila, columna).formula = "Técnico responsable:" & " " & ComboOperador.Text
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 8
                x1hoja.Cells(fila, columna).Font.Bold = True
                columna = 1
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "Este precio incluye IVA"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 8
                x1hoja.Cells(fila, columna).Font.Bold = True
                fila = fila + 2
                x1hoja.Cells(fila, columna).formula = "Este informe no podrá ser reproducido total o parcialmente sin la autorización escrita de COLAVECO."
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 8
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "Los resultados consignados se refieren exclusivamente a la muestra recibida."
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 8
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "COLAVECO declina toda responsabilidad por el uso indebido o incorrecto que se hiciere a este informe,"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 8
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "asi como el plan y procedimientos de muestreo aplicados por el cliente. Dr. Darío Hirigoyen (Director)."
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 8
            End If
        End If

        'Poner Titulos
        'x1libro.Worksheets(1).cells(1, 1).select()
        'x1libro.ActiveSheet.pictures.Insert("\\SRVCOLAVECO\D\logo.jpg").select()
        x1hoja.Shapes.AddPicture("c:\Debug\logo.jpg", _
         Microsoft.Office.Core.MsoTriState.msoFalse, _
        Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0, 80, 35)

        x1libro.Worksheets(1).cells(3, 1).select()
        'x1hoja.cells(1, 1).RowHeight = 30
        x1hoja.Cells(3, 1).columnwidth = 10
        x1hoja.Cells(3, 2).columnwidth = 20
        x1hoja.Cells(3, 3).columnwidth = 12
        x1hoja.Cells(3, 4).columnwidth = 4
        x1hoja.Cells(3, 5).columnwidth = 4
        x1hoja.Cells(3, 6).columnwidth = 4
        x1hoja.Cells(3, 7).columnwidth = 4
        x1hoja.Cells(3, 8).columnwidth = 4
        x1hoja.Cells(3, 9).columnwidth = 4
        x1hoja.Cells(3, 10).columnwidth = 4
        x1hoja.Cells(3, 11).columnwidth = 4
        x1hoja.Range("B1", "J1").Merge()
        x1hoja.Cells(1, 2).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(1, 2).Formula = "   Parque El retiro, Nueva Helvecia. Tel/Fax: 45545311 / 45545975 / 45546838"
        x1hoja.Cells(1, 2).Font.Bold = True
        x1hoja.Cells(1, 2).Font.Size = 9
        x1hoja.Range("B2", "J2").Merge()
        x1hoja.Cells(2, 2).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(2, 2).Formula = "Email: colaveco@gmail.com - Sitio: http://www.colaveco.com.uy"
        x1hoja.Cells(2, 2).Font.Bold = True
        x1hoja.Cells(2, 2).Font.Size = 9
        x1hoja.Range("B4", "J4").Merge()
        x1hoja.Cells(4, 2).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(4, 2).Formula = "INFORME DE AISLAMIENTO Y ANTIBIOGRAMA"
        x1hoja.Cells(4, 2).Font.Bold = True
        x1hoja.Cells(4, 2).Font.Size = 9
        x1hoja.Cells(8, 1).Formula = "Nº Ficha:"
        x1hoja.Cells(8, 1).Font.Bold = True
        x1hoja.Cells(8, 1).Font.Size = 9
        x1hoja.Cells(8, 4).Formula = "Fecha entrada:"
        x1hoja.Cells(8, 4).Font.Bold = True
        x1hoja.Cells(8, 4).Font.Size = 9
        x1hoja.Cells(9, 1).Formula = "Cliente:"
        x1hoja.Cells(9, 1).Font.Bold = True
        x1hoja.Cells(9, 1).Font.Size = 9
        x1hoja.Cells(9, 4).Formula = "Fecha proceso:"
        x1hoja.Cells(9, 4).Font.Bold = True
        x1hoja.Cells(9, 4).Font.Size = 9
        x1hoja.Cells(10, 4).Formula = "Fecha informe:"
        x1hoja.Cells(10, 4).Font.Bold = True
        x1hoja.Cells(10, 4).Font.Size = 9
        x1hoja.Cells(10, 1).Formula = "Dirección:"
        x1hoja.Cells(10, 1).Font.Bold = True
        x1hoja.Cells(10, 1).Font.Size = 9
        x1hoja.Cells(11, 1).Formula = "Técnico:"
        x1hoja.Cells(11, 1).Font.Bold = True
        x1hoja.Cells(11, 1).Font.Size = 9
        x1hoja.Cells(12, 1).Formula = "Caso:"
        x1hoja.Cells(12, 1).Font.Bold = True
        x1hoja.Cells(12, 1).Font.Size = 9
        x1hoja.Cells(11, 4).Formula = "Método de análisis:"
        x1hoja.Cells(11, 4).Font.Bold = True
        x1hoja.Cells(11, 4).Font.Size = 8
        x1hoja.Cells(12, 4).Formula = "Antibiograma: NCCLS-M31-A"
        x1hoja.Cells(12, 4).Font.Size = 8
        x1hoja.Cells(13, 4).Formula = "Aislamiento: National Mastitis council-1999"
        x1hoja.Cells(13, 4).Font.Size = 8
        x1hoja.Cells(14, 4).Formula = "Recuento celular: IDF 148 A: 1995"
        x1hoja.Cells(14, 4).Font.Size = 8
        x1hoja.Cells(15, 1).Formula = "Identificación"
        x1hoja.Cells(15, 1).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(15, 1).Font.Bold = True
        x1hoja.Cells(15, 1).Font.Size = 8
        x1hoja.Cells(16, 1).Formula = "Animal"
        x1hoja.Cells(16, 1).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(16, 1).Font.Bold = True
        x1hoja.Cells(16, 1).Font.Size = 8
        x1hoja.Cells(15, 2).Formula = "Microorganismo"
        x1hoja.Cells(15, 2).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(15, 2).Font.Bold = True
        x1hoja.Cells(15, 2).Font.Size = 8
        x1hoja.Cells(16, 2).Formula = "Aislado"
        x1hoja.Cells(16, 2).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(16, 2).Font.Bold = True
        x1hoja.Cells(16, 2).Font.Size = 8
        x1hoja.Cells(17, 2).Formula = "24 Hs.   48 Hs."
        x1hoja.Cells(17, 2).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(17, 2).Font.Bold = True
        x1hoja.Cells(17, 2).Font.Size = 8
        x1hoja.Cells(15, 3).Formula = "Recuento"
        x1hoja.Cells(15, 3).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(15, 3).Font.Bold = True
        x1hoja.Cells(15, 3).Font.Size = 8
        x1hoja.Cells(16, 3).Formula = "Celular"
        x1hoja.Cells(16, 3).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(16, 3).Font.Bold = True
        x1hoja.Cells(16, 3).Font.Size = 8
        x1hoja.Cells(17, 3).Formula = "(x 1000 Cel/ml)"
        x1hoja.Cells(17, 3).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(17, 3).Font.Bold = True
        x1hoja.Cells(17, 3).Font.Size = 8
        x1hoja.Range("D16", "K16").Merge()
        x1hoja.Cells(16, 4).Formula = "Familias de Antibióticos"
        x1hoja.Cells(16, 4).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(16, 4).Font.Bold = True
        x1hoja.Cells(16, 4).Font.Size = 8
        '***************************************



        x1hoja.Protect(Password:="1582782", DrawingObjects:=True, _
        Contents:=True, Scenarios:=True)
        'x1hoja.SaveAs("\\SRVCOLAVECO\D\NET\ANTIBIOGRAMA\" & idsol & ".xls")
        x1hoja.SaveAs("\\ROBOT\pre informes\ANTIBIOGRAMA\" & idsol & ".xls")

        'x1hoja.Protect(Password:="pepo", DrawingObjects:=True, _
        'Contents:=True, Scenarios:=True)
        'x1hoja.SaveAs("C:\" & idsol & ".xls")

        '***********************************
        'Insert tabla preinformes
        Dim pi As New dPreinformes
        Dim fechaactual As Date = Now()
        Dim _fecha As String
        _fecha = Format(fechaactual, "yyyy-MM-dd")
        pi.FICHA = idsol
        pi = pi.buscar
        If Not pi Is Nothing Then
        Else
            Dim pi2 As New dPreinformes
            pi2.FICHA = idsol
            pi2.TIPO = 4
            pi2.CREADO = 1
            pi2.FECHA = _fecha
            pi2.guardar()
            pi2 = Nothing
        End If
        pi = Nothing
        '************************************

        x1libro.Close()
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing
    End Sub
End Class