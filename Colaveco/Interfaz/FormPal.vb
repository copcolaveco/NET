Public Class FormPal
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
        cargarcombocolumna()
        cargarcombofila()
        cargarcomboresultado()
        cargarxdefecto()
        buscarultimonumero()
        listar()
        DateFechaActual.Value = Now
    End Sub

#End Region
    Public Sub cargarcombocolumna()
        ComboColumna.Items.Add("1")
        ComboColumna.Items.Add("2")
        ComboColumna.Items.Add("3")
        ComboColumna.Items.Add("4")
        ComboColumna.Items.Add("5")
        ComboColumna.Items.Add("6")
        ComboColumna.Items.Add("7")
        ComboColumna.Items.Add("8")
        ComboColumna.Items.Add("9")
        ComboColumna.Items.Add("10")
        ComboColumna.Items.Add("11")
        ComboColumna.Items.Add("12")
        ComboColumna.Items.Add("13")
        ComboColumna.Items.Add("14")
        ComboColumna.Items.Add("15")
    End Sub
    Public Sub cargarcombofila()
        ComboFila.Items.Add("A")
        ComboFila.Items.Add("B")
        ComboFila.Items.Add("C")
        ComboFila.Items.Add("D")
        ComboFila.Items.Add("E")
        ComboFila.Items.Add("F")
        
    End Sub
    Public Sub cargarcomboresultado()
        ComboResultado.Items.Add("Negativo")
        ComboResultado.Items.Add("Positivo")
    End Sub
    Private Sub cargarxdefecto()
        ComboColumna.Text = "1"
        ComboFila.Text = "F"
        ComboResultado.Text = "Negativo"
    End Sub
    
    Private Sub buscarultimonumero()
        Dim ultimonum As New dUltimoNumero
        ultimonum = ultimonum.buscar
        TextIdGrupal.Text = ultimonum.pal + 1
    End Sub

    Private Sub ComboColumna_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboColumna.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            ComboFila.Focus()
        End If
    End Sub

    Private Sub ComboFila_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboFila.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            TextMuestra.Focus()
        End If
    End Sub

    Private Sub TextMuestra_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextMuestra.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            TextFicha.Focus()
        End If
    End Sub

    Private Sub TextFicha_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextFicha.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            TextSerie.Focus()
        End If
    End Sub

    Private Sub ComboResultado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboResultado.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            guardar()
            listarfc()
            listar()
            columnafila()
            TextMuestra.Text = ""
            ComboResultado.Text = "Negativo"
            TextMuestra.Focus()
        End If
    End Sub

    Private Sub guardar()
        Dim idgrupal As Long = TextIdGrupal.Text.Trim
        Dim columna As Integer = ComboColumna.Text.Trim
        Dim fila As String = ComboFila.Text.Trim
        Dim fecha As Date = DateFecha.Value.ToString("yyyy-MM-dd")
        Dim fec As String
        fec = Format(fecha, "yyyy-MM-dd")
        Dim ficha As String = TextFicha.Text.Trim
        Dim serie As String = TextSerie.Text.Trim
        Dim muestra As String = TextMuestra.Text.Trim
        Dim resultado As Integer = 0
        If ComboResultado.Text = "Negativo" Then
            resultado = 0
        Else
            resultado = 1
        End If
        Dim operador As Integer = Usuario.ID

        If TextId.Text.Trim.Length > 0 Then
            Dim pal As New dPal
            Dim id As Long = TextId.Text.Trim
            pal.ID = id
            pal.IDGRUPAL = idgrupal
            pal.COLUMNA = columna
            pal.FILA = fila
            pal.FECHA = fec
            pal.FICHA = ficha
            pal.SERIE = serie
            pal.MUESTRA = muestra
            pal.RESULTADO = resultado
            pal.OPERADOR = operador

            If (pal.modificar(Usuario)) Then
                MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        Else
            Dim pal As New dPal
            Dim un As New dUltimoNumero
            un = un.buscar
            If idgrupal > un.pal Then
                pal.IDGRUPAL = idgrupal
                un.pal = idgrupal
                pal.COLUMNA = columna
                pal.FILA = fila
                pal.FECHA = fec
                pal.FICHA = ficha
                pal.SERIE = serie
                pal.MUESTRA = muestra
                pal.RESULTADO = resultado
                pal.OPERADOR = operador

                If (pal.guardar(Usuario)) Then
                    un.modificar()
                    'MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            Else
                pal.IDGRUPAL = idgrupal
                pal.COLUMNA = columna
                pal.FILA = fila
                pal.FECHA = fec
                pal.FICHA = ficha
                pal.SERIE = serie
                pal.MUESTRA = muestra
                pal.RESULTADO = resultado
                pal.OPERADOR = operador

                If (pal.guardar(Usuario)) Then
                    'MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If
        End If
    End Sub
    Private Sub listarfc()
        Dim pal As New dPal
        Dim lista1 As New ArrayList
        Dim lista2 As New ArrayList
        Dim lista3 As New ArrayList
        Dim lista4 As New ArrayList
        Dim lista5 As New ArrayList
        Dim lista6 As New ArrayList
        Dim lista7 As New ArrayList
        Dim lista8 As New ArrayList
        Dim lista9 As New ArrayList
        Dim lista10 As New ArrayList
        Dim lista11 As New ArrayList
        Dim lista12 As New ArrayList
        Dim lista13 As New ArrayList
        Dim lista14 As New ArrayList
        Dim lista15 As New ArrayList
        Dim texto As Long = TextIdGrupal.Text.Trim
        '*****************************************
        lista1 = pal.listar1(texto)
        List1.Items.Clear()
        If Not lista1 Is Nothing Then
            If lista1.Count > 0 Then
                For Each pal In lista1
                    List1().Items.Add(pal)
                Next
            End If
        End If
        '*****************************************
        lista2 = pal.listar2(texto)
        List2.Items.Clear()
        If Not lista2 Is Nothing Then
            If lista2.Count > 0 Then
                For Each pal In lista2
                    List2().Items.Add(pal)
                Next
            End If
        End If
        '*****************************************
        lista3 = pal.listar3(texto)
        List3.Items.Clear()
        If Not lista3 Is Nothing Then
            If lista3.Count > 0 Then
                For Each pal In lista3
                    List3().Items.Add(pal)
                Next
            End If
        End If
        '*****************************************
        lista4 = pal.listar4(texto)
        List4.Items.Clear()
        If Not lista4 Is Nothing Then
            If lista4.Count > 0 Then
                For Each pal In lista4
                    List4().Items.Add(pal)
                Next
            End If
        End If
        '*****************************************
        lista5 = pal.listar5(texto)
        List5.Items.Clear()
        If Not lista5 Is Nothing Then
            If lista5.Count > 0 Then
                For Each pal In lista5
                    List5().Items.Add(pal)
                Next
            End If
        End If
        '*****************************************
        lista6 = pal.listar6(texto)
        List6.Items.Clear()
        If Not lista6 Is Nothing Then
            If lista6.Count > 0 Then
                For Each pal In lista6
                    List6().Items.Add(pal)
                Next
            End If
        End If
        '*****************************************
        lista7 = pal.listar7(texto)
        List7.Items.Clear()
        If Not lista7 Is Nothing Then
            If lista7.Count > 0 Then
                For Each pal In lista7
                    List7().Items.Add(pal)
                Next
            End If
        End If
        '*****************************************
        lista8 = pal.listar8(texto)
        List8.Items.Clear()
        If Not lista8 Is Nothing Then
            If lista8.Count > 0 Then
                For Each pal In lista8
                    List8().Items.Add(pal)
                Next
            End If
        End If
        '*****************************************
        lista9 = pal.listar9(texto)
        List9.Items.Clear()
        If Not lista9 Is Nothing Then
            If lista9.Count > 0 Then
                For Each pal In lista9
                    List9().Items.Add(pal)
                Next
            End If
        End If
        '*****************************************
        lista10 = pal.listar10(texto)
        List10.Items.Clear()
        If Not lista10 Is Nothing Then
            If lista10.Count > 0 Then
                For Each pal In lista10
                    List10().Items.Add(pal)
                Next
            End If
        End If
        '*****************************************
        lista11 = pal.listar11(texto)
        List11.Items.Clear()
        If Not lista11 Is Nothing Then
            If lista11.Count > 0 Then
                For Each pal In lista11
                    List11().Items.Add(pal)
                Next
            End If
        End If
        '*****************************************
        lista12 = pal.listar12(texto)
        List12.Items.Clear()
        If Not lista12 Is Nothing Then
            If lista12.Count > 0 Then
                For Each pal In lista12
                    List12().Items.Add(pal)
                Next
            End If
        End If
        '*****************************************
        lista13 = pal.listar13(texto)
        List13.Items.Clear()
        If Not lista13 Is Nothing Then
            If lista13.Count > 0 Then
                For Each pal In lista13
                    List13().Items.Add(pal)
                Next
            End If
        End If
        '*****************************************
        lista14 = pal.listar14(texto)
        List14.Items.Clear()
        If Not lista14 Is Nothing Then
            If lista14.Count > 0 Then
                For Each pal In lista14
                    List14().Items.Add(pal)
                Next
            End If
        End If
        '*****************************************
        lista15 = pal.listar15(texto)
        List15.Items.Clear()
        If Not lista15 Is Nothing Then
            If lista15.Count > 0 Then
                For Each pal In lista15
                    List15().Items.Add(pal)
                Next
            End If
        End If
    End Sub
    Private Sub listar()
        Dim pal As New dPal
        Dim lista As New ArrayList
        lista = pal.listargrupos
        ListPal.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each pal In lista
                    ListPal().Items.Add(pal)
                Next
            End If
        End If

    End Sub

    Private Sub ListPal_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListPal.SelectedIndexChanged
        limpiar()
        If ListPal.SelectedItems.Count = 1 Then
            Dim pal As dPal = CType(ListPal.SelectedItem, dPal)
            Dim id As Long = pal.IDGRUPAL
            Dim lista1 As New ArrayList
            Dim lista2 As New ArrayList
            Dim lista3 As New ArrayList
            Dim lista4 As New ArrayList
            Dim lista5 As New ArrayList
            Dim lista6 As New ArrayList
            Dim lista7 As New ArrayList
            Dim lista8 As New ArrayList
            Dim lista9 As New ArrayList
            Dim lista10 As New ArrayList
            Dim lista11 As New ArrayList
            Dim lista12 As New ArrayList
            Dim lista13 As New ArrayList
            Dim lista14 As New ArrayList
            Dim lista15 As New ArrayList
            TextIdGrupal.Text = pal.IDGRUPAL
            '*****************************************
            lista1 = pal.listar1(id)
            List1.Items.Clear()
            If Not lista1 Is Nothing Then
                If lista1.Count > 0 Then
                    For Each pal In lista1
                        List1().Items.Add(pal)
                    Next
                End If
            End If
            '*****************************************
            lista2 = pal.listar2(id)
            List2.Items.Clear()
            If Not lista2 Is Nothing Then
                If lista2.Count > 0 Then
                    For Each pal In lista2
                        List2().Items.Add(pal)
                    Next
                End If
            End If
            '*****************************************
            lista3 = pal.listar3(id)
            List3.Items.Clear()
            If Not lista3 Is Nothing Then
                If lista3.Count > 0 Then
                    For Each pal In lista3
                        List3().Items.Add(pal)
                    Next
                End If
            End If
            '*****************************************
            lista4 = pal.listar4(id)
            List4.Items.Clear()
            If Not lista4 Is Nothing Then
                If lista4.Count > 0 Then
                    For Each pal In lista4
                        List4().Items.Add(pal)
                    Next
                End If
            End If
            '*****************************************
            lista5 = pal.listar5(id)
            List5.Items.Clear()
            If Not lista5 Is Nothing Then
                If lista5.Count > 0 Then
                    For Each pal In lista5
                        List5().Items.Add(pal)
                    Next
                End If
            End If
            '*****************************************
            lista6 = pal.listar6(id)
            List6.Items.Clear()
            If Not lista6 Is Nothing Then
                If lista6.Count > 0 Then
                    For Each pal In lista6
                        List6().Items.Add(pal)
                    Next
                End If
            End If
            '*****************************************
            lista7 = pal.listar7(id)
            List7.Items.Clear()
            If Not lista7 Is Nothing Then
                If lista7.Count > 0 Then
                    For Each pal In lista7
                        List7().Items.Add(pal)
                    Next
                End If
            End If
            '*****************************************
            lista8 = pal.listar8(id)
            List8.Items.Clear()
            If Not lista8 Is Nothing Then
                If lista8.Count > 0 Then
                    For Each pal In lista8
                        List8().Items.Add(pal)
                    Next
                End If
            End If
            '*****************************************
            lista9 = pal.listar9(id)
            List9.Items.Clear()
            If Not lista9 Is Nothing Then
                If lista9.Count > 0 Then
                    For Each pal In lista9
                        List9().Items.Add(pal)
                    Next
                End If
            End If
            '*****************************************
            lista10 = pal.listar10(id)
            List10.Items.Clear()
            If Not lista10 Is Nothing Then
                If lista10.Count > 0 Then
                    For Each pal In lista10
                        List10().Items.Add(pal)
                    Next
                End If
            End If
            '*****************************************
            lista11 = pal.listar11(id)
            List11.Items.Clear()
            If Not lista11 Is Nothing Then
                If lista11.Count > 0 Then
                    For Each pal In lista11
                        List11().Items.Add(pal)
                    Next
                End If
            End If
            '*****************************************
            lista12 = pal.listar12(id)
            List12.Items.Clear()
            If Not lista12 Is Nothing Then
                If lista12.Count > 0 Then
                    For Each pal In lista12
                        List12().Items.Add(pal)
                    Next
                End If
            End If
            '*****************************************
            lista13 = pal.listar13(id)
            List13.Items.Clear()
            If Not lista13 Is Nothing Then
                If lista13.Count > 0 Then
                    For Each pal In lista13
                        List13().Items.Add(pal)
                    Next
                End If
            End If
            '*****************************************
            lista14 = pal.listar14(id)
            List14.Items.Clear()
            If Not lista14 Is Nothing Then
                If lista14.Count > 0 Then
                    For Each pal In lista14
                        List14().Items.Add(pal)
                    Next
                End If
            End If
            '*****************************************
            lista15 = pal.listar15(id)
            List15.Items.Clear()
            If Not lista15 Is Nothing Then
                If lista15.Count > 0 Then
                    For Each pal In lista15
                        List15().Items.Add(pal)
                    Next
                End If
            End If
        End If
    End Sub

    Private Sub List1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles List1.SelectedIndexChanged
        limpiar()
       
        If List1.SelectedItems.Count = 1 Then
            Dim pal As dPal = CType(List1.SelectedItem, dPal)
            DateFecha.Value = pal.FECHA
            TextIdGrupal.Text = pal.IDGRUPAL
            ComboColumna.Text = pal.COLUMNA
            ComboFila.Text = pal.FILA
            TextMuestra.Text = pal.MUESTRA
            TextFicha.Text = pal.FICHA
            TextSerie.Text = pal.SERIE
            If pal.RESULTADO = 0 Then
                ComboResultado.Text = "Negativo"
            Else
                ComboResultado.Text = "Positivo"
            End If
            TextId.Text = pal.ID
        End If
    End Sub
    Private Sub limpiar()
        DateFecha.Value = Now
        DateFechaActual.Value = Now
        'TextIdGrupal.Text = ""
        ComboColumna.Text = ""
        ComboFila.Text = ""
        TextMuestra.Text = ""
        TextFicha.Text = ""
        TextSerie.Text = ""
        ComboResultado.Text = ""
        TextId.Text = ""
    End Sub
    Private Sub limpiar2()
        ComboColumna.Text = ""
        ComboFila.Text = ""
        TextMuestra.Text = ""
        TextFicha.Text = ""
        TextSerie.Text = ""
        ComboResultado.Text = ""
        TextId.Text = ""
        cargarxdefecto()
    End Sub

    Private Sub List2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles List2.SelectedIndexChanged
        limpiar()
        
        If List2.SelectedItems.Count = 1 Then
            Dim pal As dPal = CType(List2.SelectedItem, dPal)
            DateFecha.Value = pal.FECHA
            TextIdGrupal.Text = pal.IDGRUPAL
            ComboColumna.Text = pal.COLUMNA
            ComboFila.Text = pal.FILA
            TextMuestra.Text = pal.MUESTRA
            TextFicha.Text = pal.FICHA
            TextSerie.Text = pal.SERIE
            If pal.RESULTADO = 0 Then
                ComboResultado.Text = "Negativo"
            Else
                ComboResultado.Text = "Positivo"
            End If
            TextId.Text = pal.ID
        End If
    End Sub

    Private Sub List3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles List3.SelectedIndexChanged
        limpiar()
      
        If List3.SelectedItems.Count = 1 Then
            Dim pal As dPal = CType(List3.SelectedItem, dPal)
            DateFecha.Value = pal.FECHA
            TextIdGrupal.Text = pal.IDGRUPAL
            ComboColumna.Text = pal.COLUMNA
            ComboFila.Text = pal.FILA
            TextMuestra.Text = pal.MUESTRA
            TextFicha.Text = pal.FICHA
            TextSerie.Text = pal.SERIE
            If pal.RESULTADO = 0 Then
                ComboResultado.Text = "Negativo"
            Else
                ComboResultado.Text = "Positivo"
            End If
            TextId.Text = pal.ID
        End If
    End Sub

    Private Sub List4_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles List4.SelectedIndexChanged
        limpiar()
       
        If List4.SelectedItems.Count = 1 Then
            Dim pal As dPal = CType(List4.SelectedItem, dPal)
            DateFecha.Value = pal.FECHA
            TextIdGrupal.Text = pal.IDGRUPAL
            ComboColumna.Text = pal.COLUMNA
            ComboFila.Text = pal.FILA
            TextMuestra.Text = pal.MUESTRA
            TextFicha.Text = pal.FICHA
            TextSerie.Text = pal.SERIE
            If pal.RESULTADO = 0 Then
                ComboResultado.Text = "Negativo"
            Else
                ComboResultado.Text = "Positivo"
            End If
            TextId.Text = pal.ID
        End If
    End Sub

    Private Sub List5_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles List5.SelectedIndexChanged
        limpiar()
       
        If List5.SelectedItems.Count = 1 Then
            Dim pal As dPal = CType(List5.SelectedItem, dPal)
            DateFecha.Value = pal.FECHA
            TextIdGrupal.Text = pal.IDGRUPAL
            ComboColumna.Text = pal.COLUMNA
            ComboFila.Text = pal.FILA
            TextMuestra.Text = pal.MUESTRA
            TextFicha.Text = pal.FICHA
            TextSerie.Text = pal.SERIE
            If pal.RESULTADO = 0 Then
                ComboResultado.Text = "Negativo"
            Else
                ComboResultado.Text = "Positivo"
            End If
            TextId.Text = pal.ID
        End If
    End Sub

    Private Sub List6_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles List6.SelectedIndexChanged
        limpiar()
      
        If List6.SelectedItems.Count = 1 Then
            Dim pal As dPal = CType(List6.SelectedItem, dPal)
            DateFecha.Value = pal.FECHA
            TextIdGrupal.Text = pal.IDGRUPAL
            ComboColumna.Text = pal.COLUMNA
            ComboFila.Text = pal.FILA
            TextMuestra.Text = pal.MUESTRA
            TextFicha.Text = pal.FICHA
            TextSerie.Text = pal.SERIE
            If pal.RESULTADO = 0 Then
                ComboResultado.Text = "Negativo"
            Else
                ComboResultado.Text = "Positivo"
            End If
            TextId.Text = pal.ID
        End If
    End Sub
    Private Sub List7_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles List7.SelectedIndexChanged
        limpiar()
     
        If List7.SelectedItems.Count = 1 Then
            Dim pal As dPal = CType(List7.SelectedItem, dPal)
            DateFecha.Value = pal.FECHA
            TextIdGrupal.Text = pal.IDGRUPAL
            ComboColumna.Text = pal.COLUMNA
            ComboFila.Text = pal.FILA
            TextMuestra.Text = pal.MUESTRA
            TextFicha.Text = pal.FICHA
            TextSerie.Text = pal.SERIE
            If pal.RESULTADO = 0 Then
                ComboResultado.Text = "Negativo"
            Else
                ComboResultado.Text = "Positivo"
            End If
            TextId.Text = pal.ID
        End If
    End Sub
    Private Sub List8_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles List8.SelectedIndexChanged
        limpiar()
      
        If List8.SelectedItems.Count = 1 Then
            Dim pal As dPal = CType(List8.SelectedItem, dPal)
            DateFecha.Value = pal.FECHA
            TextIdGrupal.Text = pal.IDGRUPAL
            ComboColumna.Text = pal.COLUMNA
            ComboFila.Text = pal.FILA
            TextMuestra.Text = pal.MUESTRA
            TextFicha.Text = pal.FICHA
            TextSerie.Text = pal.SERIE
            If pal.RESULTADO = 0 Then
                ComboResultado.Text = "Negativo"
            Else
                ComboResultado.Text = "Positivo"
            End If
            TextId.Text = pal.ID
        End If
    End Sub
    Private Sub List9_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles List9.SelectedIndexChanged
        limpiar()
      
        If List9.SelectedItems.Count = 1 Then
            Dim pal As dPal = CType(List9.SelectedItem, dPal)
            DateFecha.Value = pal.FECHA
            TextIdGrupal.Text = pal.IDGRUPAL
            ComboColumna.Text = pal.COLUMNA
            ComboFila.Text = pal.FILA
            TextMuestra.Text = pal.MUESTRA
            TextFicha.Text = pal.FICHA
            TextSerie.Text = pal.SERIE
            If pal.RESULTADO = 0 Then
                ComboResultado.Text = "Negativo"
            Else
                ComboResultado.Text = "Positivo"
            End If
            TextId.Text = pal.ID
        End If
    End Sub
    Private Sub List10_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles List10.SelectedIndexChanged
        limpiar()
       
        If List10.SelectedItems.Count = 1 Then
            Dim pal As dPal = CType(List10.SelectedItem, dPal)
            DateFecha.Value = pal.FECHA
            TextIdGrupal.Text = pal.IDGRUPAL
            ComboColumna.Text = pal.COLUMNA
            ComboFila.Text = pal.FILA
            TextMuestra.Text = pal.MUESTRA
            TextFicha.Text = pal.FICHA
            TextSerie.Text = pal.SERIE
            If pal.RESULTADO = 0 Then
                ComboResultado.Text = "Negativo"
            Else
                ComboResultado.Text = "Positivo"
            End If
            TextId.Text = pal.ID
        End If
    End Sub
    Private Sub List11_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles List11.SelectedIndexChanged
        limpiar()
       
        If List11.SelectedItems.Count = 1 Then
            Dim pal As dPal = CType(List11.SelectedItem, dPal)
            DateFecha.Value = pal.FECHA
            TextIdGrupal.Text = pal.IDGRUPAL
            ComboColumna.Text = pal.COLUMNA
            ComboFila.Text = pal.FILA
            TextMuestra.Text = pal.MUESTRA
            TextFicha.Text = pal.FICHA
            TextSerie.Text = pal.SERIE
            If pal.RESULTADO = 0 Then
                ComboResultado.Text = "Negativo"
            Else
                ComboResultado.Text = "Positivo"
            End If
            TextId.Text = pal.ID
        End If
    End Sub
    Private Sub List12_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles List12.SelectedIndexChanged
        limpiar()
      
        If List12.SelectedItems.Count = 1 Then
            Dim pal As dPal = CType(List12.SelectedItem, dPal)
            DateFecha.Value = pal.FECHA
            TextIdGrupal.Text = pal.IDGRUPAL
            ComboColumna.Text = pal.COLUMNA
            ComboFila.Text = pal.FILA
            TextMuestra.Text = pal.MUESTRA
            TextFicha.Text = pal.FICHA
            TextSerie.Text = pal.SERIE
            If pal.RESULTADO = 0 Then
                ComboResultado.Text = "Negativo"
            Else
                ComboResultado.Text = "Positivo"
            End If
            TextId.Text = pal.ID
        End If
    End Sub
    Private Sub List13_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles List13.SelectedIndexChanged
        limpiar()
       
        If List13.SelectedItems.Count = 1 Then
            Dim pal As dPal = CType(List13.SelectedItem, dPal)
            DateFecha.Value = pal.FECHA
            TextIdGrupal.Text = pal.IDGRUPAL
            ComboColumna.Text = pal.COLUMNA
            ComboFila.Text = pal.FILA
            TextMuestra.Text = pal.MUESTRA
            TextFicha.Text = pal.FICHA
            TextSerie.Text = pal.SERIE
            If pal.RESULTADO = 0 Then
                ComboResultado.Text = "Negativo"
            Else
                ComboResultado.Text = "Positivo"
            End If
            TextId.Text = pal.ID
        End If
    End Sub
    Private Sub List14_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles List14.SelectedIndexChanged
        limpiar()
       
        If List14.SelectedItems.Count = 1 Then
            Dim pal As dPal = CType(List14.SelectedItem, dPal)
            DateFecha.Value = pal.FECHA
            TextIdGrupal.Text = pal.IDGRUPAL
            ComboColumna.Text = pal.COLUMNA
            ComboFila.Text = pal.FILA
            TextMuestra.Text = pal.MUESTRA
            TextFicha.Text = pal.FICHA
            TextSerie.Text = pal.SERIE
            If pal.RESULTADO = 0 Then
                ComboResultado.Text = "Negativo"
            Else
                ComboResultado.Text = "Positivo"
            End If
            TextId.Text = pal.ID
        End If
    End Sub
    Private Sub List15_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles List15.SelectedIndexChanged
        limpiar()
      
        If List15.SelectedItems.Count = 1 Then
            Dim pal As dPal = CType(List15.SelectedItem, dPal)
            DateFecha.Value = pal.FECHA
            TextIdGrupal.Text = pal.IDGRUPAL
            ComboColumna.Text = pal.COLUMNA
            ComboFila.Text = pal.FILA
            TextMuestra.Text = pal.MUESTRA
            TextFicha.Text = pal.FICHA
            TextSerie.Text = pal.SERIE
            If pal.RESULTADO = 0 Then
                ComboResultado.Text = "Negativo"
            Else
                ComboResultado.Text = "Positivo"
            End If
            TextId.Text = pal.ID
        End If
    End Sub
    Private Sub ComboResultado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboResultado.SelectedIndexChanged

    End Sub

    Private Sub ButtonEliminarR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEliminarR.Click
        If TextId.Text <> "" Then
            Dim pal As New dPal
            Dim id As Long = CType(TextId.Text, Long)
            pal.ID = id
            If (pal.eliminar(Usuario)) Then
                MsgBox("Registro eliminado", MsgBoxStyle.Information, "Atención")
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
        limpiar()
        listar()
        listarfc()
    End Sub

    Private Sub ButtonFinalizado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFinalizado.Click
        If ListPal.SelectedItems.Count = 1 Then
            Dim pal As dPal = CType(ListPal.SelectedItem, dPal)
            Dim id As Long = pal.IDGRUPAL
            Dim fechaactual As Date = DateFechaActual.Value.ToString("yyyy-MM-dd")
            Dim fecact As String
            fecact = Format(fechaactual, "yyyy-MM-dd")
            pal.marcar(id, fecact, Usuario)
        End If
        listar()
        listarfc()
        List1.Items.Clear()
        List2.Items.Clear()
        List3.Items.Clear()
        List4.Items.Clear()
        List5.Items.Clear()
        List6.Items.Clear()
        List7.Items.Clear()
        List8.Items.Clear()
        List9.Items.Clear()
        List10.Items.Clear()
        List11.Items.Clear()
        List12.Items.Clear()
        List13.Items.Clear()
        List14.Items.Clear()
        List15.Items.Clear()
        buscarultimonumero()
    End Sub

    Private Sub ButtonAgregarR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        limpiar2()
    End Sub

    Private Sub ButtonNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNuevo.Click
        limpiar()
        List1.Items.Clear()
        List2.Items.Clear()
        List3.Items.Clear()
        List4.Items.Clear()
        List5.Items.Clear()
        List6.Items.Clear()
        List7.Items.Clear()
        List8.Items.Clear()
        List9.Items.Clear()
        List10.Items.Clear()
        List11.Items.Clear()
        List12.Items.Clear()
        List13.Items.Clear()
        List14.Items.Clear()
        List15.Items.Clear()
        buscarultimonumero()
        cargarxdefecto()
        TextMuestra.Focus()
    End Sub
    Private Sub columnafila()
        If ComboColumna.Text = "1" And ComboFila.Text = "F" Then
            ComboColumna.Text = "2"
            ComboFila.Text = "F"
        ElseIf ComboColumna.Text = "2" And ComboFila.Text = "F" Then
            ComboColumna.Text = "3"
            ComboFila.Text = "F"
        ElseIf ComboColumna.Text = "3" And ComboFila.Text = "F" Then
            ComboColumna.Text = "4"
            ComboFila.Text = "F"
        ElseIf ComboColumna.Text = "4" And ComboFila.Text = "F" Then
            ComboColumna.Text = "5"
            ComboFila.Text = "F"
        ElseIf ComboColumna.Text = "5" And ComboFila.Text = "F" Then
            ComboColumna.Text = "6"
            ComboFila.Text = "F"
        ElseIf ComboColumna.Text = "6" And ComboFila.Text = "F" Then
            ComboColumna.Text = "7"
            ComboFila.Text = "F"
        ElseIf ComboColumna.Text = "7" And ComboFila.Text = "F" Then
            ComboColumna.Text = "8"
            ComboFila.Text = "F"
        ElseIf ComboColumna.Text = "8" And ComboFila.Text = "F" Then
            ComboColumna.Text = "9"
            ComboFila.Text = "F"
        ElseIf ComboColumna.Text = "9" And ComboFila.Text = "F" Then
            ComboColumna.Text = "10"
            ComboFila.Text = "F"
        ElseIf ComboColumna.Text = "10" And ComboFila.Text = "F" Then
            ComboColumna.Text = "11"
            ComboFila.Text = "F"
        ElseIf ComboColumna.Text = "11" And ComboFila.Text = "F" Then
            ComboColumna.Text = "12"
            ComboFila.Text = "F"
        ElseIf ComboColumna.Text = "12" And ComboFila.Text = "F" Then
            ComboColumna.Text = "13"
            ComboFila.Text = "F"
        ElseIf ComboColumna.Text = "13" And ComboFila.Text = "F" Then
            ComboColumna.Text = "14"
            ComboFila.Text = "F"
        ElseIf ComboColumna.Text = "14" And ComboFila.Text = "F" Then
            ComboColumna.Text = "15"
            ComboFila.Text = "F"
        ElseIf ComboColumna.Text = "15" And ComboFila.Text = "F" Then
            ComboColumna.Text = "1"
            ComboFila.Text = "E"
            '************************************************************
        ElseIf ComboColumna.Text = "1" And ComboFila.Text = "E" Then
            ComboColumna.Text = "2"
            ComboFila.Text = "E"
        ElseIf ComboColumna.Text = "2" And ComboFila.Text = "E" Then
            ComboColumna.Text = "3"
            ComboFila.Text = "E"
        ElseIf ComboColumna.Text = "3" And ComboFila.Text = "E" Then
            ComboColumna.Text = "4"
            ComboFila.Text = "E"
        ElseIf ComboColumna.Text = "4" And ComboFila.Text = "E" Then
            ComboColumna.Text = "5"
            ComboFila.Text = "E"
        ElseIf ComboColumna.Text = "5" And ComboFila.Text = "E" Then
            ComboColumna.Text = "6"
            ComboFila.Text = "E"
        ElseIf ComboColumna.Text = "6" And ComboFila.Text = "E" Then
            ComboColumna.Text = "7"
            ComboFila.Text = "E"
        ElseIf ComboColumna.Text = "7" And ComboFila.Text = "E" Then
            ComboColumna.Text = "8"
            ComboFila.Text = "E"
        ElseIf ComboColumna.Text = "8" And ComboFila.Text = "E" Then
            ComboColumna.Text = "9"
            ComboFila.Text = "E"
        ElseIf ComboColumna.Text = "9" And ComboFila.Text = "E" Then
            ComboColumna.Text = "10"
            ComboFila.Text = "E"
        ElseIf ComboColumna.Text = "10" And ComboFila.Text = "E" Then
            ComboColumna.Text = "11"
            ComboFila.Text = "E"
        ElseIf ComboColumna.Text = "11" And ComboFila.Text = "E" Then
            ComboColumna.Text = "12"
            ComboFila.Text = "E"
        ElseIf ComboColumna.Text = "12" And ComboFila.Text = "E" Then
            ComboColumna.Text = "13"
            ComboFila.Text = "E"
        ElseIf ComboColumna.Text = "13" And ComboFila.Text = "E" Then
            ComboColumna.Text = "14"
            ComboFila.Text = "E"
        ElseIf ComboColumna.Text = "14" And ComboFila.Text = "E" Then
            ComboColumna.Text = "15"
            ComboFila.Text = "E"
        ElseIf ComboColumna.Text = "15" And ComboFila.Text = "E" Then
            ComboColumna.Text = "1"
            ComboFila.Text = "D"
            '************************************************************
        ElseIf ComboColumna.Text = "1" And ComboFila.Text = "D" Then
            ComboColumna.Text = "2"
            ComboFila.Text = "D"
        ElseIf ComboColumna.Text = "2" And ComboFila.Text = "D" Then
            ComboColumna.Text = "3"
            ComboFila.Text = "D"
        ElseIf ComboColumna.Text = "3" And ComboFila.Text = "D" Then
            ComboColumna.Text = "4"
            ComboFila.Text = "D"
        ElseIf ComboColumna.Text = "4" And ComboFila.Text = "D" Then
            ComboColumna.Text = "5"
            ComboFila.Text = "D"
        ElseIf ComboColumna.Text = "5" And ComboFila.Text = "D" Then
            ComboColumna.Text = "6"
            ComboFila.Text = "D"
        ElseIf ComboColumna.Text = "6" And ComboFila.Text = "D" Then
            ComboColumna.Text = "7"
            ComboFila.Text = "D"
        ElseIf ComboColumna.Text = "7" And ComboFila.Text = "D" Then
            ComboColumna.Text = "8"
            ComboFila.Text = "D"
        ElseIf ComboColumna.Text = "8" And ComboFila.Text = "D" Then
            ComboColumna.Text = "9"
            ComboFila.Text = "D"
        ElseIf ComboColumna.Text = "9" And ComboFila.Text = "D" Then
            ComboColumna.Text = "10"
            ComboFila.Text = "D"
        ElseIf ComboColumna.Text = "10" And ComboFila.Text = "D" Then
            ComboColumna.Text = "11"
            ComboFila.Text = "D"
        ElseIf ComboColumna.Text = "11" And ComboFila.Text = "D" Then
            ComboColumna.Text = "12"
            ComboFila.Text = "D"
        ElseIf ComboColumna.Text = "12" And ComboFila.Text = "D" Then
            ComboColumna.Text = "13"
            ComboFila.Text = "D"
        ElseIf ComboColumna.Text = "13" And ComboFila.Text = "D" Then
            ComboColumna.Text = "14"
            ComboFila.Text = "D"
        ElseIf ComboColumna.Text = "14" And ComboFila.Text = "D" Then
            ComboColumna.Text = "15"
            ComboFila.Text = "D"
        ElseIf ComboColumna.Text = "15" And ComboFila.Text = "D" Then
            ComboColumna.Text = "1"
            ComboFila.Text = "C"
            '************************************************************
        ElseIf ComboColumna.Text = "1" And ComboFila.Text = "C" Then
            ComboColumna.Text = "2"
            ComboFila.Text = "C"
        ElseIf ComboColumna.Text = "2" And ComboFila.Text = "C" Then
            ComboColumna.Text = "3"
            ComboFila.Text = "C"
        ElseIf ComboColumna.Text = "3" And ComboFila.Text = "C" Then
            ComboColumna.Text = "4"
            ComboFila.Text = "C"
        ElseIf ComboColumna.Text = "4" And ComboFila.Text = "C" Then
            ComboColumna.Text = "5"
            ComboFila.Text = "C"
        ElseIf ComboColumna.Text = "5" And ComboFila.Text = "C" Then
            ComboColumna.Text = "6"
            ComboFila.Text = "C"
        ElseIf ComboColumna.Text = "6" And ComboFila.Text = "C" Then
            ComboColumna.Text = "7"
            ComboFila.Text = "C"
        ElseIf ComboColumna.Text = "7" And ComboFila.Text = "C" Then
            ComboColumna.Text = "8"
            ComboFila.Text = "C"
        ElseIf ComboColumna.Text = "8" And ComboFila.Text = "C" Then
            ComboColumna.Text = "9"
            ComboFila.Text = "C"
        ElseIf ComboColumna.Text = "9" And ComboFila.Text = "C" Then
            ComboColumna.Text = "10"
            ComboFila.Text = "C"
        ElseIf ComboColumna.Text = "10" And ComboFila.Text = "C" Then
            ComboColumna.Text = "11"
            ComboFila.Text = "C"
        ElseIf ComboColumna.Text = "11" And ComboFila.Text = "C" Then
            ComboColumna.Text = "12"
            ComboFila.Text = "C"
        ElseIf ComboColumna.Text = "12" And ComboFila.Text = "C" Then
            ComboColumna.Text = "13"
            ComboFila.Text = "C"
        ElseIf ComboColumna.Text = "13" And ComboFila.Text = "C" Then
            ComboColumna.Text = "14"
            ComboFila.Text = "C"
        ElseIf ComboColumna.Text = "14" And ComboFila.Text = "C" Then
            ComboColumna.Text = "15"
            ComboFila.Text = "C"
        ElseIf ComboColumna.Text = "15" And ComboFila.Text = "C" Then
            ComboColumna.Text = "1"
            ComboFila.Text = "B"
            '************************************************************
        ElseIf ComboColumna.Text = "1" And ComboFila.Text = "B" Then
            ComboColumna.Text = "2"
            ComboFila.Text = "B"
        ElseIf ComboColumna.Text = "2" And ComboFila.Text = "B" Then
            ComboColumna.Text = "3"
            ComboFila.Text = "B"
        ElseIf ComboColumna.Text = "3" And ComboFila.Text = "B" Then
            ComboColumna.Text = "4"
            ComboFila.Text = "B"
        ElseIf ComboColumna.Text = "4" And ComboFila.Text = "B" Then
            ComboColumna.Text = "5"
            ComboFila.Text = "B"
        ElseIf ComboColumna.Text = "5" And ComboFila.Text = "B" Then
            ComboColumna.Text = "6"
            ComboFila.Text = "B"
        ElseIf ComboColumna.Text = "6" And ComboFila.Text = "B" Then
            ComboColumna.Text = "7"
            ComboFila.Text = "B"
        ElseIf ComboColumna.Text = "7" And ComboFila.Text = "B" Then
            ComboColumna.Text = "8"
            ComboFila.Text = "B"
        ElseIf ComboColumna.Text = "8" And ComboFila.Text = "B" Then
            ComboColumna.Text = "9"
            ComboFila.Text = "B"
        ElseIf ComboColumna.Text = "9" And ComboFila.Text = "B" Then
            ComboColumna.Text = "10"
            ComboFila.Text = "B"
        ElseIf ComboColumna.Text = "10" And ComboFila.Text = "B" Then
            ComboColumna.Text = "11"
            ComboFila.Text = "B"
        ElseIf ComboColumna.Text = "11" And ComboFila.Text = "B" Then
            ComboColumna.Text = "12"
            ComboFila.Text = "B"
        ElseIf ComboColumna.Text = "12" And ComboFila.Text = "B" Then
            ComboColumna.Text = "13"
            ComboFila.Text = "B"
        ElseIf ComboColumna.Text = "13" And ComboFila.Text = "B" Then
            ComboColumna.Text = "14"
            ComboFila.Text = "B"
        ElseIf ComboColumna.Text = "14" And ComboFila.Text = "B" Then
            ComboColumna.Text = "15"
            ComboFila.Text = "B"
        ElseIf ComboColumna.Text = "15" And ComboFila.Text = "B" Then
            ComboColumna.Text = "1"
            ComboFila.Text = "A"
            '************************************************************
        ElseIf ComboColumna.Text = "1" And ComboFila.Text = "A" Then
            ComboColumna.Text = "2"
            ComboFila.Text = "A"
        ElseIf ComboColumna.Text = "2" And ComboFila.Text = "A" Then
            ComboColumna.Text = "3"
            ComboFila.Text = "A"
        ElseIf ComboColumna.Text = "3" And ComboFila.Text = "A" Then
            ComboColumna.Text = "4"
            ComboFila.Text = "A"
        ElseIf ComboColumna.Text = "4" And ComboFila.Text = "A" Then
            ComboColumna.Text = "5"
            ComboFila.Text = "A"
        ElseIf ComboColumna.Text = "5" And ComboFila.Text = "A" Then
            ComboColumna.Text = "6"
            ComboFila.Text = "A"
        ElseIf ComboColumna.Text = "6" And ComboFila.Text = "A" Then
            ComboColumna.Text = "7"
            ComboFila.Text = "A"
        ElseIf ComboColumna.Text = "7" And ComboFila.Text = "A" Then
            ComboColumna.Text = "8"
            ComboFila.Text = "A"
        ElseIf ComboColumna.Text = "8" And ComboFila.Text = "A" Then
            ComboColumna.Text = "9"
            ComboFila.Text = "A"
        ElseIf ComboColumna.Text = "9" And ComboFila.Text = "A" Then
            ComboColumna.Text = "10"
            ComboFila.Text = "A"
        ElseIf ComboColumna.Text = "10" And ComboFila.Text = "A" Then
            ComboColumna.Text = "11"
            ComboFila.Text = "A"
        ElseIf ComboColumna.Text = "11" And ComboFila.Text = "A" Then
            ComboColumna.Text = "12"
            ComboFila.Text = "A"
        ElseIf ComboColumna.Text = "12" And ComboFila.Text = "A" Then
            ComboColumna.Text = "13"
            ComboFila.Text = "A"
        ElseIf ComboColumna.Text = "13" And ComboFila.Text = "A" Then
            ComboColumna.Text = "14"
            ComboFila.Text = "A"
        ElseIf ComboColumna.Text = "14" And ComboFila.Text = "A" Then
            ComboColumna.Text = "15"
            ComboFila.Text = "A"
        ElseIf ComboColumna.Text = "15" And ComboFila.Text = "A" Then
            ComboColumna.Text = "1"
            ComboFila.Text = "F"
        End If
    End Sub
    Private Sub TextSerie_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextSerie.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            ComboResultado.Focus()
        End If
    End Sub

End Class