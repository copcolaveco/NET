Public Class FormAgua2
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
        listarfichas()
        limpiar()
    End Sub
#End Region

    Public Sub listarfichas()
        Dim a As New dAgua3
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

    Public Sub listaragua()
        limpiar()
        If ListFichas.SelectedItems.Count = 1 Then
            Dim a As dAgua3 = CType(ListFichas.SelectedItem, dAgua3)
            Dim id As Long = a.ficha
            idsol = id
            Dim lista As New ArrayList
            lista = a.listarporsolicitud(id)
            ListMuestras.Items.Clear()
            If Not lista Is Nothing Then
                If lista.Count > 0 Then
                    For Each a In lista
                        ListMuestras().Items.Add(a)
                    Next
                End If
            End If
        End If
    End Sub
    Private Sub limpiar()
        TextFicha.Text = ""
        DateFechaSolicitud.Value = Now()
        TextMuestra.Text = ""
        TextObservaciones.Text = ""
        TextTipoInforme.Text = ""
       
    
     
        TextDatos.Text = ""
        deshabilitarcontroles()
    End Sub
    

    Private Sub ListFichas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListFichas.SelectedIndexChanged
        limpiar()
        If ListFichas.SelectedItems.Count = 1 Then
            Dim a As dAgua3 = CType(ListFichas.SelectedItem, dAgua3)
            Dim id As Long = a.ficha
            Dim lista As New ArrayList
            lista = a.listarporid(id)
            ListMuestras.Items.Clear()
            If Not lista Is Nothing Then
                If lista.Count > 0 Then
                    For Each a In lista
                        ListMuestras().Items.Add(a)
                    Next
                End If
            End If
        End If
        habilitarcontroles()
    End Sub

    Private Sub ListMuestras_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListMuestras.SelectedIndexChanged
        limpiar()
        If ListMuestras.SelectedItems.Count = 1 Then
            Dim a As dAgua3 = CType(ListMuestras.SelectedItem, dAgua3)
            TextId.Text = a.ID
            TextFicha.Text = a.ficha
            DateFechaSolicitud.Value = a.FECHAENTRADA
            ComboOperador.Text = Usuario.NOMBRE
            TextMuestra.Text = a.IDMUESTRA

           
            '************************************************
            If a.CA <> -1 Then
                TextCa.Text = a.CA
            End If
            If a.MG <> -1 Then
                TextMg.Text = a.MG
            End If
            If a.NA <> -1 Then
                TextNa.Text = a.NA
            End If
            If a.FE <> -1 Then
                TextFe.Text = a.FE
            End If
            If a.K <> -1 Then
                TextK.Text = a.K
            End If
            If a.AL <> -1 Then
                TextAl.Text = a.AL
            End If
            If a.CD <> -1 Then
                TextCd.Text = a.CD
            End If
            If a.CR <> -1 Then
                TextCr.Text = a.CR
            End If
            If a.CU <> -1 Then
                TextCu.Text = a.CU
            End If
            If a.PB <> -1 Then
                TextPb.Text = a.PB
            End If
            If a.MN <> -1 Then
                TextMn.Text = a.MN
            End If
            If a.FEM <> -1 Then
                TextFem.Text = a.FEM
            End If
            If a.ZN <> -1 Then
                TextZn.Text = a.ZN
            End If
            If a.SE <> -1 Then
                TextSe.Text = a.SE
            End If
            '********************************************
            Dim sa As New dSolicitudAnalisis
            Dim id As Long = TextFicha.Text.Trim
            sa.ID = id
            sa = sa.buscar()
            If Not sa.OBSERVACIONES Is Nothing Then
                TextObservaciones.Text = sa.OBSERVACIONES
            End If

            Dim si As New dSubInforme
            si.ID = sa.IDSUBINFORME
            si = si.buscar()
            TextTipoInforme.Text = si.NOMBRE & " "
            '*********************************************
            Dim a1 As New dAgua
            a1.ID = id
            a1 = a1.buscar()

            If a1.CA = 1 Then
                TextTipoInforme.Text = TextTipoInforme.Text & " " & "+ CA" & " "
            End If
            If a1.MG = 1 Then
                TextTipoInforme.Text = TextTipoInforme.Text & " " & "+ MG" & " "
            End If
            If a1.NA = 1 Then
                TextTipoInforme.Text = TextTipoInforme.Text & " " & "+ NA" & " "
            End If
            If a1.FE = 1 Then
                TextTipoInforme.Text = TextTipoInforme.Text & " " & "+ FE" & " "
            End If
            If a1.K = 1 Then
                TextTipoInforme.Text = TextTipoInforme.Text & " " & "+ K" & " "
            End If
            If a1.AL = 1 Then
                TextTipoInforme.Text = TextTipoInforme.Text & " " & "+ AL" & " "
            End If
            If a1.CD = 1 Then
                TextTipoInforme.Text = TextTipoInforme.Text & " " & "+ Cd" & " "
            End If
            If a1.CR = 1 Then
                TextTipoInforme.Text = TextTipoInforme.Text & " " & "+ Cr" & " "
            End If
            If a1.CU = 1 Then
                TextTipoInforme.Text = TextTipoInforme.Text & " " & "+ CU" & " "
            End If
            If a1.PB = 1 Then
                TextTipoInforme.Text = TextTipoInforme.Text & " " & "+ PB" & " "
            End If
            If a1.MN = 1 Then
                TextTipoInforme.Text = TextTipoInforme.Text & " " & "+ mn" & " "
            End If
            If a1.FEM = 1 Then
                TextTipoInforme.Text = TextTipoInforme.Text & " " & "+ FE" & " "
            End If
            If a1.ZN = 1 Then
                TextTipoInforme.Text = TextTipoInforme.Text & " " & "+ ZN" & " "
            End If
            If a1.SE = 1 Then
                TextTipoInforme.Text = TextTipoInforme.Text & " " & "+ SE" & " "
            End If

        End If

    End Sub

    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        guardar()
    End Sub
    Private Sub guardar()
        Dim ficha As Long = TextFicha.Text.Trim
        Dim fechaentrada As Date = DateFechaSolicitud.Value.ToString("yyyy-MM-dd")
        Dim fechaent As String
        fechaent = Format(fechaentrada, "yyyy-MM-dd")
        Dim fechaemision As Date = Now()
        Dim fechaemi As String
        fechaemi = Format(fechaemision, "yyyy-MM-dd")
        If TextMuestra.Text.Trim.Length = 0 Then MsgBox("No se ha ingresado la muestra", MsgBoxStyle.Exclamation, "Atención") : TextMuestra.Focus() : Exit Sub
        Dim idmuestra As String = TextMuestra.Text.Trim
        Dim observaciones As String = ""
        If TextObservaciones.Text <> "" Then
            observaciones = TextObservaciones.Text
        End If
        Dim ca As Double
        If TextCa.Text <> "" Then
            ca = TextCa.Text.Trim
        Else
            ca = -1
        End If
        Dim mg As Double
        If TextMg.Text <> "" Then
            mg = TextMg.Text.Trim
        Else
            mg = -1
        End If
        Dim na As Double
        If TextNa.Text <> "" Then
            na = TextNa.Text.Trim
        Else
            na = -1
        End If
        Dim fe As Double
        If TextFe.Text <> "" Then
            fe = TextFe.Text.Trim
        Else
            fe = -1
        End If
        Dim k As Double
        If TextK.Text <> "" Then
            k = TextK.Text.Trim
        Else
            k = -1
        End If
        Dim al As Double
        If TextAl.Text <> "" Then
            al = TextAl.Text.Trim
        Else
            al = -1
        End If
        Dim cd As Double
        If TextCd.Text <> "" Then
            cd = TextCd.Text.Trim
        Else
            cd = -1
        End If
        Dim cr As Double
        If TextCr.Text <> "" Then
            cr = TextCr.Text.Trim
        Else
            cr = -1
        End If
        Dim cu As Double
        If TextCu.Text <> "" Then
            cu = TextCu.Text.Trim
        Else
            cu = -1
        End If
        Dim pb As Double
        If TextPb.Text <> "" Then
            pb = TextPb.Text.Trim
        Else
            pb = -1
        End If
        Dim mn As Double
        If TextMn.Text <> "" Then
            mn = TextMn.Text.Trim
        Else
            mn = -1
        End If
        Dim fem As Double
        If TextFem.Text <> "" Then
            fem = TextFem.Text.Trim
        Else
            fem = -1
        End If
        Dim zn As Double
        If TextZn.Text <> "" Then
            zn = TextZn.Text.Trim
        Else
            zn = -1
        End If
        Dim se As Double
        If TextSe.Text <> "" Then
            se = TextSe.Text.Trim
        Else
            se = -1
        End If
        Dim operador As Integer = Usuario.ID
        If TextId.Text.Trim.Length > 0 Then
            Dim a As New dAgua3()
            Dim id As Long = CType(TextId.Text.Trim, Long)
            a.ID = id
            a.ficha = ficha
            a.FECHAENTRADA = fechaent
            a.FECHAEMISION = fechaemi
            a.IDMUESTRA = idmuestra
            a.OBSERVACIONES = observaciones
            a.CA = ca
            a.MG = mg
            a.NA = na
            a.FE = fe
            a.K = k
            a.AL = al
            a.CD = cd
            a.CR = cr
            a.CU = cu
            a.PB = pb
            a.MN = mn
            a.FEM = fem
            a.ZN = zn
            a.SE = se
            a.OPERADOR = operador
            a.MARCA = 0
            If (a.modificar(Usuario)) Then
                MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        Else
            Dim a As New dAgua3()
            a.FICHA = ficha
            a.FECHAENTRADA = fechaent
            a.FECHAEMISION = fechaemi
            a.IDMUESTRA = idmuestra
            a.OBSERVACIONES = observaciones
            a.CA = ca
            a.MG = mg
            a.NA = na
            a.FE = fe
            a.K = k
            a.AL = al
            a.CD = cd
            a.CR = cr
            a.CU = cu
            a.PB = pb
            a.MN = mn
            a.FEM = fem
            a.ZN = zn
            a.SE = se
            a.OPERADOR = operador
            a.MARCA = 0
            If (a.guardar(Usuario)) Then
                MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
    End Sub

  
    Public Sub deshabilitarcontroles()
        TextCa.Enabled = False
        TextMg.Enabled = False
        TextNa.Enabled = False
        TextFe.Enabled = False
        TextK.Enabled = False
        TextAl.Enabled = False
        TextCd.Enabled = False
        TextCr.Enabled = False
        TextCu.Enabled = False
        TextPb.Enabled = False
        TextMn.Enabled = False
        TextFem.Enabled = False
        TextZn.Enabled = False
        TextSe.Enabled = False
    End Sub
    Public Sub habilitarcontroles()
        Dim a As New dAgua
        a.ID = idsol
        a = a.buscar
        If Not a Is Nothing Then
            If a.CA = 1 Then
                TextCa.Enabled = True
            End If
            If a.MG = 1 Then
                TextMg.Enabled = True
            End If
            If a.NA = 1 Then
                TextNa.Enabled = True
            End If
            If a.FE = 1 Then
                TextFe.Enabled = True
            End If
            If a.K = 1 Then
                TextK.Enabled = True
            End If
            If a.AL = 1 Then
                TextAl.Enabled = True
            End If
            If a.CD = 1 Then
                TextCd.Enabled = True
            End If
            If a.CR = 1 Then
                TextCr.Enabled = True
            End If
            If a.CU = 1 Then
                TextCu.Enabled = True
            End If
            If a.PB = 1 Then
                TextPb.Enabled = True
            End If
            If a.MN = 1 Then
                TextMn.Enabled = True
            End If
            If a.FEM = 1 Then
                TextFem.Enabled = True
            End If
            If a.ZN = 1 Then
                TextZn.Enabled = True
            End If
            If a.SE = 1 Then
                TextSe.Enabled = True
            End If
        End If
    End Sub

End Class