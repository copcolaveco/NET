Public Class FormNuevoAnalisis
    Private _usuario As dUsuario
    Private _ficha As Long = 0
    Private _muestra As String = ""
    Private completo As Integer = 1
    Private completo2 As Integer = 1
    Private xxanalisis As Integer = 0
    Private proxfila As Integer = 0
    Private cuenta_filas As Integer = 0
    Private tipoinforme As Integer = 0
    Private _logo As Integer = 0
    Public Property Usuario() As dUsuario
        Get
            Return _usuario
        End Get
        Set(ByVal value As dUsuario)
            _usuario = value
        End Set
    End Property
#Region "Constructores"
    Public Sub New(ByVal u As dUsuario, ByVal tipoinf As Integer)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u
        tipoinforme = tipoinf
        listarfichas()
        listarlaboratorios()
        DateFecha.Value = Now
    End Sub
#End Region
    Private Sub listarlaboratorios()
        Dim ol As New dOtrosLaboratorios
        Dim lista As New ArrayList
        lista = ol.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each ol In lista
                    ComboLaboratorios.Items.Add(ol)
                Next
            End If
        End If
    End Sub
    Private Sub listarfichas()
        Dim n As New dNuevoAnalisis
        Dim lista As New ArrayList

        If tipoinforme = 10 Then
            lista = n.listarfichasMineralesLeche(tipoinforme)
        Else
            lista = n.listarfichasnuevas(tipoinforme)
        End If

        Dim fila As Integer = 0
        Dim columna As Integer = 0
        DataGridView1.Rows.Clear()
        DataGridView2.Rows.Clear()
        DataGridView3.Rows.Clear()
        DataGridView4.Rows.Clear()
        DataGridView5.Rows.Clear()
        If Not lista Is Nothing Then
            DataGridView1.Rows.Add(lista.Count)
            For Each n In lista
                DataGridView1(columna, fila).Value = n.ID
                columna = columna + 1
                DataGridView1(columna, fila).Value = n.FICHA
                columna = 0
                fila = fila + 1
            Next
        End If
        'LISTAR FICHAS CON SOLO ANALISIS TERCERIZADOS
        Dim at As New dAnalisisTercerizado
        Dim listaat As New ArrayList
        listaat = at.listarfichasnuevas(tipoinforme)
        If Not listaat Is Nothing Then
            For Each at In listaat
                Dim n2 As New dNuevoAnalisis
                n2.FICHA = at.FICHA
                n2 = n2.buscarxficha
                If Not n2 Is Nothing Then
                Else
                    DataGridView1.Rows.Add(1)
                    DataGridView1(columna, fila).Value = at.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = at.FICHA
                    columna = 0
                    fila = fila + 1
                End If
            Next
        End If
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        TextObsInternas.Text = ""
        If DataGridView1.Columns(e.ColumnIndex).Name = "Fichas" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            id = row.Cells("Fichas").Value
            _ficha = id
            Dim sa As New dSolicitudAnalisis
            sa.ID = _ficha
            sa = sa.buscar
            Dim obsint As String = ""
            If Not sa Is Nothing Then
                If sa.OBSINTERNAS <> "" Then
                    obsint = sa.OBSINTERNAS
                    TextObsInternas.Text = obsint
                End If
                If sa.MUESTREO = 1 Then
                    Dim v As New FormDetalle_Muestreo(Usuario, _ficha)
                    v.Show()
                End If
            End If
            Dim n As New dNuevoAnalisis
            Dim lista As New ArrayList
            lista = n.listarporfichamuestra(id)
            Dim fila As Integer = 0
            Dim columna As Integer = 0
            DataGridView2.Rows.Clear()
            DataGridView3.Rows.Clear()
            If Not lista Is Nothing Then
                DataGridView2.Rows.Add(lista.Count)
                For Each n In lista
                    DataGridView2(columna, fila).Value = n.ID
                    columna = columna + 1
                    DataGridView2(columna, fila).Value = n.MUESTRA
                    columna = 0
                    fila = fila + 1
                Next
            End If
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "Fichas" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            id = row.Cells("Fichas").Value
            _ficha = id
            Dim at As New dAnalisisTercerizado
            Dim lista As New ArrayList
            lista = at.listarporfichamuestra(id)
            Dim fila As Integer = 0
            Dim columna As Integer = 0
            DataGridView4.Rows.Clear()
            DataGridView5.Rows.Clear()
            If Not lista Is Nothing Then
                DataGridView5.Rows.Add(lista.Count)
                For Each at In lista
                    DataGridView5(columna, fila).Value = at.ID
                    columna = columna + 1
                    DataGridView5(columna, fila).Value = at.MUESTRA
                    columna = 0
                    fila = fila + 1
                Next
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
       
    End Sub

    Private Sub DataGridView2_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellClick
        If DataGridView2.Columns(e.ColumnIndex).Name = "Muestras" Then
            Dim meto As Integer = 0
            Dim uni As Integer = 0
            Dim row As DataGridViewRow = DataGridView2.Rows(e.RowIndex)
            Dim muestra As String = ""
            muestra = row.Cells("Muestras").Value
            _muestra = muestra
            Dim n As New dNuevoAnalisis
            Dim lista As New ArrayList
            lista = n.listarpormuestra(_ficha, _muestra)
            cuenta_filas = lista.Count
            Dim fila As Integer = 0
            Dim columna As Integer = 0
            DataGridView3.Rows.Clear()
            If Not lista Is Nothing Then
                DataGridView3.Rows.Add(lista.Count)
                For Each n In lista
                    TextDetalle.Text = n.DETALLEMUESTRA
                    DataGridView3(columna, fila).Value = n.ID
                    columna = columna + 1
                    Dim lp As New dListaPrecios
                    lp.ID = n.ANALISIS
                    lp = lp.buscar
                    If lp.ACREDITADO = 1 Then
                        _logo = 1
                    End If
                    If Not lp Is Nothing Then
                        DataGridView3(columna, fila).Value = lp.DESCRIPCION
                        columna = columna + 1
                    Else
                        DataGridView3(columna, fila).Value = ""
                        columna = columna + 1
                    End If
                    DataGridView3(columna, fila).Value = n.RESULTADO & " " & n.RESULTADO2
                    'columna = 0
                    'fila = fila + 1
                    columna = columna + 2
                    Dim lm As New dListaMetodos
                    lm.ID = n.METODO
                    lm = lm.buscar
                    If Not lm Is Nothing Then
                        DataGridView3(columna, fila).Value = lm.METODO
                        columna = columna + 2
                    Else
                        'DataGridView3(columna, fila).Value =
                        'columna = columna + 2
                        Dim lm2 As New dListaMetodos
                        Dim listaana As New ArrayList
                        Dim _ana As Integer = n.ANALISIS
                        Dim linea As Long = 0
                        linea = n.ID
                        listaana = lm2.listarxanalisis(_ana)
                        If Not listaana Is Nothing Then
                            If listaana.Count = 1 Then
                                For Each lm2 In listaana
                                    meto = lm2.ID
                                    DataGridView3(columna, fila).Value = lm2.METODO
                                    'columna = columna + 2
                                Next
                            ElseIf listaana.Count > 1 Then
                                For Each lm2 In listaana
                                    If lm2.PORDEFECTO = 1 Then
                                        meto = lm2.ID
                                        DataGridView3(columna, fila).Value = lm2.METODO
                                        'columna = columna + 2
                                    End If
                                Next
                            End If
                            columna = columna + 2
                            Dim na2 As New dNuevoAnalisis
                            Dim metodo2 As Integer = 0
                            metodo2 = meto
                            na2.ID = linea
                            na2.METODO = metodo2
                            na2.actualizar_metodo(Usuario)
                            meto = 0
                            na2 = Nothing
                        End If
                    End If
                    Dim au As New dAnalisisUnidad
                    au.ID = n.UNIDAD
                    au = au.buscar
                    If Not au Is Nothing Then
                        DataGridView3(columna, fila).Value = au.UNIDAD
                        columna = 0
                        'fila = fila + 1
                    Else
                        'DataGridView3(columna, fila).Value = ""
                        'columna = 0
                        'fila = fila + 1
                        Dim au2 As New dAnalisisUnidad
                        Dim listauni As New ArrayList
                        Dim _ana As Integer = n.ANALISIS
                        Dim linea As Long = 0
                        linea = n.ID
                        listauni = au2.listarxanalisis(_ana)
                        If Not listauni Is Nothing Then
                            If listauni.Count = 1 Then
                                For Each au2 In listauni
                                    uni = au2.ID
                                    DataGridView3(columna, fila).Value = au2.UNIDAD
                                    columna = 0
                                    'fila = fila + 1
                                Next
                            ElseIf listauni.Count > 1 Then
                                For Each au2 In listauni
                                    If au2.PORDEFECTO = 1 Then
                                        uni = au2.ID
                                        DataGridView3(columna, fila).Value = au2.UNIDAD
                                        columna = 0
                                        'fila = fila + 1
                                    End If
                                Next
                            End If
                            Dim na3 As New dNuevoAnalisis
                            Dim unidad2 As Integer = 0
                            unidad2 = uni
                            na3.ID = linea
                            na3.UNIDAD = unidad2
                            na3.actualizar_unidad(Usuario)
                            uni = 0
                            na3 = Nothing
                        Else
                            columna = 0

                        End If
                    End If
                    fila = fila + 1
                    columna = 0
                Next
            End If
        End If

        'If DataGridView2.Columns(e.ColumnIndex).Name = "Muestras" Then
        '    Dim row As DataGridViewRow = DataGridView2.Rows(e.RowIndex)
        '    Dim muestra As String = ""
        '    muestra = row.Cells("Muestras").Value
        '    _muestra = muestra
        '    Dim at As New dAnalisisTercerizado
        '    Dim lista2 As New ArrayList
        '    lista2 = at.listarpormuestra(_ficha, _muestra)
        '    If Not lista2 Is Nothing Then
        '        cuenta_filas = lista2.Count
        '    End If

        '    Dim fila2 As Integer = 0
        '    Dim columna2 As Integer = 0
        '    DataGridView4.Rows.Clear()
        '    If Not lista2 Is Nothing Then
        '        DataGridView4.Rows.Add(lista2.Count)
        '        For Each at In lista2
        '            DataGridView4(columna2, fila2).Value = at.ID
        '            columna2 = columna2 + 1
        '            Dim att As New dAnalisisTercerizadoTipo
        '            att.ID = at.ANALISIS
        '            att = att.buscar
        '            If Not att Is Nothing Then
        '                DataGridView4(columna2, fila2).Value = att.NOMBRE
        '                columna2 = columna2 + 1
        '            Else
        '                DataGridView4(columna2, fila2).Value = ""
        '                columna2 = columna2 + 1
        '            End If
        '            DataGridView4(columna2, fila2).Value = at.RESULTADO
        '            columna2 = columna2 + 2
        '            DataGridView4(columna2, fila2).Value = at.METODO
        '            columna2 = columna2 + 2
        '            DataGridView4(columna2, fila2).Value = at.UNIDAD
        '            columna2 = columna2 + 2
        '            Dim ol As New dOtrosLaboratorios
        '            ol.ID = at.LABORATORIO
        '            ol = ol.buscar
        '            If Not ol Is Nothing Then
        '                DataGridView4(columna2, fila2).Value = ol.NOMBRE
        '                columna2 = 0
        '                fila2 = fila2 + 1
        '            Else
        '                DataGridView4(columna2, fila2).Value = ""
        '                columna2 = 0
        '                fila2 = fila2 + 1
        '            End If
        '        Next
        '    End If
        'End If
        If DataGridView2.Columns(e.ColumnIndex).Name = "Detalle" Then
            Dim row As DataGridViewRow = DataGridView2.Rows(e.RowIndex)
            Dim muestra As String = ""
            muestra = row.Cells("Muestras").Value
            _muestra = muestra
            Dim n As New dNuevoAnalisis
            Dim lista As New ArrayList
            lista = n.listarpormuestra(_ficha, _muestra)
            Dim v As New FormCompletoDetalleMuestra(_ficha, _muestra, Usuario)
            v.ShowDialog()
        End If
    End Sub

    Private Sub DataGridView3_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView3.CellClick
        Dim tc As Integer = 0
        Dim ficha As Long = 0
        Dim nanalisis As String = ""
        Dim idanal As Integer = 0
        Dim idmetodo As Integer = 0
        Dim idunidad As Integer = 0
        If DataGridView3.Columns(e.ColumnIndex).Name = "Cargar" Then
            Dim row As DataGridViewRow = DataGridView3.Rows(e.RowIndex)
            Dim id As Long = 0
            id = row.Cells("Id3").Value
            Dim n As New dNuevoAnalisis
            n.ID = id
            n = n.buscar
            If Not n Is Nothing Then
                Dim lp As New dListaPrecios
                ficha = n.FICHA
                lp.ID = n.ANALISIS
                idanal = n.ANALISIS
                lp = lp.buscar
                If Not lp Is Nothing Then
                    tc = lp.TIPOCONTROL
                    nanalisis = lp.DESCRIPCION
                End If
            End If
            If tc = 1 Then
                Dim v As New FormCompletoTextBox(id, nanalisis, Usuario)
                v.ShowDialog()
                listar()
            ElseIf tc = 2 Then
                Dim v As New FormCompletoComboBox(id, idanal, nanalisis, Usuario)
                v.ShowDialog()
                listar()
            ElseIf tc = 3 Then
                Dim v As New FormCompletoComboTextBox(id, idanal, nanalisis, Usuario)
                v.ShowDialog()
                listar()
            ElseIf tc = 4 Then
                Dim v As New FormCompletoTextBox2(id, idanal, nanalisis, Usuario)
                v.ShowDialog()
                v.TextResultado.Focus()
                listar()
            ElseIf tc = 5 Then
                Dim v As New FormCompletoMemo(id, nanalisis, Usuario)
                v.ShowDialog()
                listar()
            ElseIf tc = 6 Then
                Dim v As New FormCompletoATB(id, ficha, _muestra, Usuario, idanal)
                v.ShowDialog()
                'CONTROLO SI ESTA COMPELTO EN ANALISIS DE LA MUESTRA ********************
                Dim atb As New dATB
                Dim lista As New ArrayList
                Dim primero As Integer = 0
                Dim segundo As Integer = 0
                Dim cuenta1 As Integer = 0
                Dim cuenta2 As Integer = 0
                Dim total As Integer = 0
                lista = atb.listardiferentes(_ficha, _muestra)
                If Not lista Is Nothing Then
                    If lista.Count = 1 Then
                        For Each atb In lista
                            primero = atb.AISLAMIENTO
                        Next
                    ElseIf lista.Count = 2 Then
                        Dim contador As Integer = 1
                        For Each atb In lista
                            If contador = 1 Then
                                primero = atb.AISLAMIENTO
                            ElseIf contador = 2 Then
                                segundo = atb.AISLAMIENTO
                            End If
                            contador = contador + 1
                        Next
                    End If
                    Dim microatb1 As New dMicroATB
                    Dim microatb2 As New dMicroATB
                    Dim lista1 As New ArrayList
                    Dim lista2 As New ArrayList
                    lista1 = microatb1.listarxmicro(primero)
                    lista2 = microatb2.listarxmicro(segundo)
                    If Not lista1 Is Nothing Then
                        cuenta1 = lista1.Count
                    End If
                    If Not lista2 Is Nothing Then
                        cuenta2 = lista2.Count
                    End If
                    total = cuenta1 + cuenta2
                    Dim atb2 As New dATB
                    Dim listaatb2 As New ArrayList
                    listaatb2 = atb2.listarxfichaxmuestra(ficha, _muestra)
                    If Not listaatb2 Is Nothing Then
                        If idanal = 11 Or idanal = 316 Or atb.AISLAMIENTO = 1 Or atb.AISLAMIENTO = 2 Then
                            Dim na As New dNuevoAnalisis
                            na.FICHA = ficha
                            na.MUESTRA = _muestra
                            na.RESULTADO = "Completo"
                            na.actualizar_resultado2(Usuario)
                        Else
                            If total = listaatb2.Count Then
                                Dim na As New dNuevoAnalisis
                                na.FICHA = ficha
                                na.MUESTRA = _muestra
                                na.RESULTADO = "Completo"
                                na.actualizar_resultado2(Usuario)
                            End If
                        End If
                       
                    End If
                End If
                '*************************************************************************
                listar()
            End If
            'Dim proxfila As Integer = 0
            proxfila = e.RowIndex + 1
            'DataGridView3.Rows(proxfila).Cells(3).Selected = True
            DataGridView3.CurrentCell = DataGridView3(3, proxfila)

            Dim row2 As DataGridViewRow = DataGridView3.Rows(proxfila)
            Dim id2 As Long = 0
            id2 = row2.Cells("Id3").Value
            xxanalisis = id2
        End If
        If DataGridView3.Columns(e.ColumnIndex).Name = "Met" Then
            Dim row As DataGridViewRow = DataGridView3.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim id_ As Long = 0
            id = row.Cells("Id3").Value
            id_ = id
            Dim n As New dNuevoAnalisis
            n.ID = id
            n = n.buscar
            If Not n Is Nothing Then
                Dim lp As New dListaPrecios
                lp.ID = n.ANALISIS
                idanal = n.ANALISIS
                lp = lp.buscar
                If Not lp Is Nothing Then
                    tc = lp.TIPOCONTROL
                    nanalisis = lp.DESCRIPCION
                End If
            End If
            Dim vv As New FormCompletoMetodo(id_, idanal, Usuario)
            vv.ShowDialog()
            listar()
        End If
        If DataGridView3.Columns(e.ColumnIndex).Name = "Uni" Then
            Dim row As DataGridViewRow = DataGridView3.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim id_ As Long = 0
            id = row.Cells("Id3").Value
            id_ = id
            Dim n As New dNuevoAnalisis
            n.ID = id
            n = n.buscar
            If Not n Is Nothing Then
                Dim lp As New dListaPrecios
                lp.ID = n.ANALISIS
                idanal = n.ANALISIS
                lp = lp.buscar
                If Not lp Is Nothing Then
                    tc = lp.TIPOCONTROL
                    nanalisis = lp.DESCRIPCION
                End If
            End If
            Dim vv As New FormCompletoUnidad(id_, idanal, Usuario)
            vv.ShowDialog()
            listar()
        End If
        If DataGridView3.Columns(e.ColumnIndex).Name = "Eliminar" Then
            Dim row As DataGridViewRow = DataGridView3.Rows(e.RowIndex)
            Dim id As Long = 0
            id = row.Cells("Id3").Value
            Dim n As New dNuevoAnalisis
            n.ID = id
            Dim result = MessageBox.Show("Desea eliminar el análisis?", "Atención!", MessageBoxButtons.YesNoCancel)
            If result = DialogResult.Cancel Then
            ElseIf result = DialogResult.No Then
            Else
                n.eliminar(Usuario)
            End If
            listar()
        End If
    End Sub
    Private Sub listar()
        Dim n As New dNuevoAnalisis
        Dim lista As New ArrayList
        lista = n.listarpormuestra(_ficha, _muestra)
        Dim fila As Integer = 0
        Dim columna As Integer = 0
        DataGridView3.Rows.Clear()
        If Not lista Is Nothing Then
            DataGridView3.Rows.Add(lista.Count)
            For Each n In lista
                TextDetalle.Text = n.DETALLEMUESTRA
                DataGridView3(columna, fila).Value = n.ID
                columna = columna + 1
                Dim lp As New dListaPrecios
                lp.ID = n.ANALISIS
                lp = lp.buscar
                If Not lp Is Nothing Then
                    DataGridView3(columna, fila).Value = lp.DESCRIPCION
                    columna = columna + 1
                Else
                    DataGridView3(columna, fila).Value = ""
                    columna = columna + 1
                End If
                DataGridView3(columna, fila).Value = n.RESULTADO & " " & n.RESULTADO2
                columna = columna + 2
                Dim lm As New dListaMetodos
                lm.ID = n.METODO
                lm = lm.buscar
                If Not lm Is Nothing Then
                    DataGridView3(columna, fila).Value = lm.METODO
                    columna = columna + 2
                Else
                    Dim lm2 As New dListaMetodos
                    Dim listaana As New ArrayList
                    Dim _ana As Integer = n.ANALISIS
                    Dim linea As Long = 0
                    linea = n.ID
                    listaana = lm2.listarxanalisis(_ana)
                    If Not listaana Is Nothing Then
                        If listaana.Count = 1 Then
                            For Each lm2 In listaana
                                DataGridView3(columna, fila).Value = lm2.METODO
                            Next
                        ElseIf listaana.Count > 1 Then
                            For Each lm2 In listaana
                                If lm2.PORDEFECTO = 1 Then
                                    DataGridView3(columna, fila).Value = lm2.METODO
                                End If
                            Next
                        End If
                        columna = columna + 2
                        Dim na2 As New dNuevoAnalisis
                        Dim metodo2 As Integer = 0
                        metodo2 = lm2.ID
                        na2.ID = linea
                        na2.METODO = metodo2
                        na2.actualizar_metodo(Usuario)
                    End If
                End If
                Dim au As New dAnalisisUnidad
                au.ID = n.UNIDAD
                au = au.buscar
                If Not au Is Nothing Then
                    DataGridView3(columna, fila).Value = au.UNIDAD
                    columna = 0
                Else
                    Dim au2 As New dAnalisisUnidad
                    Dim listauni As New ArrayList
                    Dim _ana As Integer = n.ANALISIS
                    Dim linea As Long = 0
                    linea = n.ID
                    listauni = au2.listarxanalisis(_ana)
                    If Not listauni Is Nothing Then
                        If listauni.Count = 1 Then
                            For Each au2 In listauni
                                DataGridView3(columna, fila).Value = au2.UNIDAD
                                columna = 0
                            Next
                        ElseIf listauni.Count > 1 Then
                            For Each au2 In listauni
                                If au2.PORDEFECTO = 1 Then
                                    DataGridView3(columna, fila).Value = au2.UNIDAD
                                    columna = 0
                                End If
                            Next
                        End If
                        Dim na3 As New dNuevoAnalisis
                        Dim unidad2 As Integer = 0
                        unidad2 = au2.ID
                        na3.ID = linea
                        na3.UNIDAD = unidad2
                        na3.actualizar_unidad(Usuario)
                    Else
                        columna = 0
                    End If
                End If
                fila = fila + 1
            Next
        End If
    End Sub
    Private Sub listar2()
        Dim at As New dAnalisisTercerizado
        Dim lista As New ArrayList
        lista = at.listarpormuestra(_ficha, _muestra)
        Dim fila As Integer = 0
        Dim columna As Integer = 0
        DataGridView4.Rows.Clear()
        If Not lista Is Nothing Then
            DataGridView4.Rows.Add(lista.Count)
            For Each at In lista
                DataGridView4(columna, fila).Value = at.ID
                columna = columna + 1
                Dim att As New dAnalisisTercerizadoTipo
                att.ID = at.ANALISIS
                att = att.buscar
                If Not att Is Nothing Then
                    DataGridView4(columna, fila).Value = att.NOMBRE
                    columna = columna + 1
                Else
                    DataGridView4(columna, fila).Value = ""
                    columna = columna + 1
                End If
                DataGridView4(columna, fila).Value = at.RESULTADO
                columna = columna + 2
                DataGridView4(columna, fila).Value = at.METODO
                columna = columna + 2
                DataGridView4(columna, fila).Value = at.UNIDAD
                columna = columna + 2
                Dim ol As New dOtrosLaboratorios
                ol.ID = at.LABORATORIO
                ol = ol.buscar
                If Not ol Is Nothing Then
                    DataGridView4(columna, fila).Value = ol.NOMBRE
                    columna = 0
                    fila = fila + 1
                Else
                    DataGridView4(columna, fila).Value = ""
                    columna = 0
                    fila = fila + 1
                End If
             
            Next
        End If
    End Sub

    Private Sub ButtonFinalizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFinalizar.Click
        If Not DataGridView1.SelectedColumns Is Nothing Then
            If tipoinforme = 9 Then
                Dim v2 As New FormCompletoConclusion(_ficha, Usuario)
                v2.ShowDialog()
            End If
            If tipoinforme = 13 Then
                Dim v3 As New FormObservacionNutricion(Usuario, _ficha)
                v3.ShowDialog()
                Dim v4 As New FormInterpretacionesNutricion(Usuario, _ficha)
                v4.ShowDialog()
            Else
                Dim v3 As New FormObservaciones(Usuario, _ficha)
                v3.ShowDialog()
            End If
            If tipoinforme = 7 Then
                'If _logo = 1 Then
                Dim result = MessageBox.Show("¿El informe debe salir con el logo de OUA?", "Atención!", MessageBoxButtons.YesNoCancel)
                If result = DialogResult.Cancel Then

                ElseIf result = DialogResult.No Then

                ElseIf result = DialogResult.Yes Then
                    Dim sa As New dSolicitudAnalisis
                    sa.ID = _ficha
                    sa.marcarlogo(Usuario)
                End If
                'End If
            End If
            'CHEQUEA QUE ESTE TODO ANALISIS COMPLETO
            completo = 1
            chequear_completo()
            'CHEQUEA QUE ESTE TODO ANALISIS TERCERIZADO COMPLETO
            completo2 = 1
            Dim sa2 As New dSolicitudAnalisis
            sa2.ID = _ficha
            sa2 = sa2.buscar
            If Not sa2 Is Nothing Then
                If sa2.IDTIPOINFORME <> 9 Then
                    chequear_completo2()
                End If
            End If

            If completo = 1 And completo2 = 1 Then
                Dim na As New dNuevoAnalisis
                Dim at As New dAnalisisTercerizado
                Dim fecha As Date = DateFecha.Value.ToString("yyyy-MM-dd")
                Dim fec As String
                fec = Format(fecha, "yyyy-MM-dd")
                na.FICHA = _ficha
                na.FECHAPROCESO = fec
                na.asignaroperador(Usuario)
                na.actualizar_fecha(Usuario)
                na.marcarfinalizado(Usuario)
                at.FICHA = _ficha
                at.FECHAPROCESO = fec
                at.asignaroperador(Usuario)
                at.actualizar_fecha(Usuario)
                at.marcarfinalizado(Usuario)
                TextDetalle.Text = ""
                listarfichas()
            Else
                MsgBox("Faltan completar datos!")
            End If
        End If
    End Sub
    Private Sub chequear_completo()
        Dim na As New dNuevoAnalisis
        Dim lista As New ArrayList
        lista = na.listarporficha2(_ficha)
        If Not lista Is Nothing Then
            For Each na In lista
                Dim lp As New dListaPrecios
                lp.ID = na.ANALISIS
                lp = lp.buscar
                If Not lp Is Nothing Then
                    If lp.TIPOCONTROL = 1 Then
                        If na.RESULTADO2 = "" Then
                            completo = 0
                            Exit Sub
                        End If
                    ElseIf lp.TIPOCONTROL = 2 Then
                        If na.RESULTADO = "" Then
                            completo = 0
                            Exit Sub
                        End If
                    ElseIf lp.TIPOCONTROL = 3 Then
                        If na.RESULTADO = "" And na.RESULTADO2 = "" Then
                            completo = 0
                            Exit Sub
                        End If
                    ElseIf lp.TIPOCONTROL = 4 Then
                        If na.RESULTADO = "" And na.RESULTADO2 = "" Then
                            completo = 0
                            Exit Sub
                        End If
                    ElseIf lp.TIPOCONTROL = 5 Then
                        If na.RESULTADO2 = "" Then
                            completo = 0
                            Exit Sub
                        End If
                    ElseIf lp.TIPOCONTROL = 6 Then
                        If na.RESULTADO = "" Then
                            completo = 0
                            Exit Sub
                        End If
                    End If
                End If
            Next
        End If
    End Sub
    Private Sub chequear_completo2()
        Dim at As New dAnalisisTercerizado
        Dim lista As New ArrayList
        lista = at.listarporficha2(_ficha)
        If Not lista Is Nothing Then
            For Each at In lista
                If at.ELIMINADO = 0 Then
                    If at.MUESTRA = "" Then
                        completo2 = 0
                    End If
                    If at.ANALISIS = 0 Then
                        completo2 = 0
                    End If
                    If tipoinforme <> 8 Then
                        If at.RESULTADO = "" Then
                            completo2 = 0
                        End If
                    End If
                    If tipoinforme <> 8 Then
                        If at.UNIDAD = "" Then
                            completo2 = 0
                        End If
                    End If
                    If at.METODO = "" Then
                        completo2 = 0
                    End If
                    If at.LABORATORIO = 0 Then
                        completo2 = 0
                    End If
                End If
            Next
        End If
    End Sub
    Private Sub DataGridView3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DataGridView3.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            Dim tc As Integer = 0
            Dim nanalisis As String = ""
            Dim idanal As Integer = 0
            Dim idmetodo As Integer = 0
            Dim idunidad As Integer = 0

            'Dim row As DataGridViewRow = DataGridView3.CurrentCell.RowIndex
            Dim id As Long = 0
            'id = row.Cells("Id3").Value
            id = xxanalisis
            Dim n As New dNuevoAnalisis
            n.ID = id
            n = n.buscar
            If Not n Is Nothing Then
                Dim lp As New dListaPrecios
                lp.ID = n.ANALISIS
                idanal = n.ANALISIS
                lp = lp.buscar
                If Not lp Is Nothing Then
                    tc = lp.TIPOCONTROL
                    nanalisis = lp.DESCRIPCION
                End If
            End If
            If tc = 1 Then
                Dim v As New FormCompletoTextBox(id, nanalisis, Usuario)
                v.ShowDialog()
                listar()
            ElseIf tc = 2 Then
                Dim v As New FormCompletoComboBox(id, idanal, nanalisis, Usuario)
                v.ShowDialog()
                listar()
            ElseIf tc = 3 Then
                Dim v As New FormCompletoComboTextBox(id, idanal, nanalisis, Usuario)
                v.ShowDialog()
                listar()
            ElseIf tc = 4 Then
                Dim v As New FormCompletoTextBox2(id, idanal, nanalisis, Usuario)
                v.ShowDialog()
                listar()
            ElseIf tc = 5 Then
                Dim v As New FormCompletoMemo(id, nanalisis, Usuario)
                v.ShowDialog()
                listar()
            ElseIf tc = 6 Then
                Dim v As New FormCompletoATB(id, idanal, nanalisis, Usuario, idanal)
                v.ShowDialog()
                listar()
            End If
            If proxfila < cuenta_filas Then
                proxfila = proxfila + 1
            End If
            'DataGridView3.Rows(proxfila).Cells(3).Selected = True
            DataGridView3.CurrentCell = DataGridView3(3, proxfila)
            Dim row2 As DataGridViewRow = DataGridView3.Rows(proxfila)
            Dim id2 As Long = 0
            id2 = row2.Cells("Id3").Value
            xxanalisis = id2


        End If
    End Sub

    Private Sub DataGridView3_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView3.CellContentClick

    End Sub

    Private Sub DataGridView4_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView4.CellClick
        Dim tc As Integer = 0
        Dim nanalisis As String = ""
        Dim idanal As Integer = 0
        Dim idmetodo As Integer = 0
        Dim idunidad As Integer = 0

        If DataGridView4.Columns(e.ColumnIndex).Name = "Cargar2" Then
            Dim row As DataGridViewRow = DataGridView4.Rows(e.RowIndex)
            Dim id As Long = 0
            id = row.Cells("Id4").Value
            Dim at As New dAnalisisTercerizado
            at.ID = id
            at = at.buscar
            If Not at Is Nothing Then
                Dim att As New dAnalisisTercerizadoTipo
                att.ID = at.ANALISIS
                idanal = at.ANALISIS
                att = att.buscar
                If Not att Is Nothing Then
                    nanalisis = att.NOMBRE
                End If
            End If
            If at.TIPOINFORME = 9 Then
                Dim v As New FormCompletoTercerizado2(id, nanalisis, Usuario)
                v.ShowDialog()
             
                listar2()
            Else
                Dim v As New FormCompletoTercerizado(id, nanalisis, Usuario)
                v.ShowDialog()
                listar2()
            End If
          
            'Dim proxfila As Integer = 0
            proxfila = e.RowIndex + 1
            'DataGridView3.Rows(proxfila).Cells(3).Selected = True
            DataGridView4.CurrentCell = DataGridView4(3, proxfila)
            Dim row2 As DataGridViewRow = DataGridView4.Rows(proxfila)
            Dim id2 As Long = 0
            id2 = row2.Cells("Id4").Value
            xxanalisis = id2
        End If
        If DataGridView4.Columns(e.ColumnIndex).Name = "Met2" Then
            Dim row As DataGridViewRow = DataGridView4.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim id_ As Long = 0
            id = row.Cells("Id4").Value
            id_ = id
            Dim at As New dAnalisisTercerizado
            at.ID = id
            at = at.buscar
            If Not at Is Nothing Then
                Dim att As New dAnalisisTercerizadoTipo
                att.ID = at.ANALISIS
                idanal = at.ANALISIS
                att = att.buscar
                If Not att Is Nothing Then
                    nanalisis = att.NOMBRE
                End If
            End If
            Dim vv As New FormCompletoMetodo2(id_, idanal, Usuario)
            vv.ShowDialog()
            listar2()
        End If
        If DataGridView4.Columns(e.ColumnIndex).Name = "Uni2" Then
            Dim row As DataGridViewRow = DataGridView4.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim id_ As Long = 0
            id = row.Cells("Id4").Value
            id_ = id
            Dim at As New dAnalisisTercerizado
            at.ID = id
            at = at.buscar
            If Not at Is Nothing Then
                Dim att As New dAnalisisTercerizadoTipo
                att.ID = at.ANALISIS
                idanal = at.ANALISIS
                att = att.buscar
                If Not att Is Nothing Then
                    nanalisis = att.NOMBRE
                End If
            End If
            Dim vv As New FormCompletoUnidad2(id_, idanal, Usuario)
            vv.ShowDialog()
            listar2()
        End If
        If DataGridView4.Columns(e.ColumnIndex).Name = "Lab2" Then
            Dim row As DataGridViewRow = DataGridView4.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim id_ As Long = 0
            id = row.Cells("Id4").Value
            id_ = id
            Dim at As New dAnalisisTercerizado
            at.ID = id
            at = at.buscar
            If Not at Is Nothing Then
                Dim att As New dAnalisisTercerizadoTipo
                att.ID = at.ANALISIS
                idanal = at.ANALISIS
                att = att.buscar
                If Not att Is Nothing Then
                    nanalisis = att.NOMBRE
                End If
            End If
            Dim vv As New FormCompletoLaboratorio(id_, idanal, Usuario)
            vv.ShowDialog()
            listar2()
        End If
        If DataGridView4.Columns(e.ColumnIndex).Name = "X" Then
            Dim row As DataGridViewRow = DataGridView4.Rows(e.RowIndex)
            Dim id As Long = 0
            id = row.Cells("Id4").Value
            Dim at As New dAnalisisTercerizado
            at.ID = id
            at.marcareliminado(Usuario)
            listar2()
        End If
    End Sub
    Private Sub DataGridView5_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView5.CellClick
        If DataGridView5.Columns(e.ColumnIndex).Name = "Muestras2" Then
            Dim row As DataGridViewRow = DataGridView5.Rows(e.RowIndex)
            Dim muestra As String = ""
            muestra = row.Cells("Muestras2").Value
            _muestra = muestra
            Dim at As New dAnalisisTercerizado
            Dim lista2 As New ArrayList
            lista2 = at.listarpormuestra(_ficha, _muestra)
            If Not lista2 Is Nothing Then
                cuenta_filas = lista2.Count
            End If
            Dim fila2 As Integer = 0
            Dim columna2 As Integer = 0
            DataGridView4.Rows.Clear()
            If Not lista2 Is Nothing Then
                DataGridView4.Rows.Add(lista2.Count)
                For Each at In lista2
                    DataGridView4(columna2, fila2).Value = at.ID
                    columna2 = columna2 + 1
                    Dim att As New dAnalisisTercerizadoTipo
                    att.ID = at.ANALISIS
                    att = att.buscar
                    If Not att Is Nothing Then
                        DataGridView4(columna2, fila2).Value = att.NOMBRE
                        columna2 = columna2 + 1
                    Else
                        DataGridView4(columna2, fila2).Value = ""
                        columna2 = columna2 + 1
                    End If
                    DataGridView4(columna2, fila2).Value = at.RESULTADO
                    columna2 = columna2 + 2
                    DataGridView4(columna2, fila2).Value = at.METODO
                    columna2 = columna2 + 2
                    DataGridView4(columna2, fila2).Value = at.UNIDAD
                    columna2 = columna2 + 2
                    Dim ol As New dOtrosLaboratorios
                    ol.ID = at.LABORATORIO
                    ol = ol.buscar
                    If Not ol Is Nothing Then
                        DataGridView4(columna2, fila2).Value = ol.NOMBRE
                        columna2 = 0
                        fila2 = fila2 + 1
                    Else
                        DataGridView4(columna2, fila2).Value = ""
                        columna2 = 0
                        fila2 = fila2 + 1
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub DataGridView4_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView4.CellContentClick

    End Sub

    Private Sub DataGridView4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DataGridView4.KeyPress

    End Sub

    Private Sub ButtonCompletarLaboratorio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCompletarLaboratorio.Click
        Dim olab As dOtrosLaboratorios = CType(ComboLaboratorios.SelectedItem, dOtrosLaboratorios)
        Dim lab As Integer = 0
        If Not olab Is Nothing Then
            lab = olab.ID
            Dim at As New dAnalisisTercerizado
            at.FICHA = _ficha
            at.LABORATORIO = lab
            at.modificarlaboratorios(Usuario)
            MsgBox("Registro completado!")
        End If
    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

    End Sub
End Class