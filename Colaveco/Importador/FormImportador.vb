Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Imports System
Imports System.IO
Imports System.Collections
Public Class FormImportador
#Region "Constructores"
    Public Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Label2.Text = ""
        Timer1.Enabled = False
        importar()
    End Sub
#End Region


    Private Sub calidadcsv()
        Dim extension As String
        Dim nombrearchivo As String = ""
        Dim linea As Integer
        Dim folder As New DirectoryInfo("Y:\Documentos\SECRETARIA\Analisis\Leche\Bentley-delta\Calidad de leche")

        Dim _ficheros() As String
        _ficheros = Directory.GetFiles("Y:\Documentos\SECRETARIA\Analisis\Leche\Bentley-delta\Calidad de leche")
        If Not (_ficheros.Length > 0) Then

        Else


            For Each file As FileInfo In folder.GetFiles("*.csv")
                'ListBox1.Items.Add(file.Name)
                nombrearchivo = file.Name
                If nombrearchivo.Length < 12 Then 'controlo si el archivo es de delta 400
                    linea = 1
                    extension = Microsoft.VisualBasic.Right(file.Name, 3)
                    'Dim objReader As New StreamReader("d:\documentos\secretaria\analisis\leche\bentley-delta\pasados\calidad de leche\" & file.Name)
                    Dim objReader As New StreamReader("Y:\documentos\secretaria\analisis\leche\bentley-delta\Calidad de leche\" & file.Name)
                    Dim sLine As String = ""
                    Dim arraytext() As String



                    Dim matricula As String = ""
                    Dim grasa As Double = 0
                    Dim proteina As Double = 0
                    Dim lactosa As Double = 0
                    Dim st As Double = 0
                    Dim rc As Integer = 0
                    Dim ficha As String = ""
                    Dim ficha2 As String = ""
                    Dim ficha3 As String = ""
                    Dim equipo As String = ""
                    Dim producto As String = ""
                    Dim crioscopia As Integer = 0
                    Dim urea As Integer = 0
                    Dim proteinav As Double = 0
                    Dim caseina As Double = 0
                    Dim densidad As Double = 0
                    Dim ph As Double = 0
                    ' *** SI EL ARCHIVO ES CSV **************************************************************************************
                    If extension = "csv" Or extension = "CSV" Then
                        Dim c As New dImpCalidad()
                        Do
                            sLine = objReader.ReadLine()
                            If sLine <> " " Then
                                If linea = 3 Then
                                    arraytext = Split(sLine, ";")
                                    If arraytext.Length < 11 Then
                                        arraytext = Split(sLine, ",")
                                    End If
                                    producto = Trim(arraytext(10))
                                End If
                                If Not sLine Is Nothing Then
                                    If linea >= 8 Then
                                        'arrText.Add(sLine)
                                        arraytext = Split(sLine, ";")
                                        If arraytext.Length < 39 Then
                                            arraytext = Split(sLine, ",")
                                        End If
                                        matricula = Trim(arraytext(5))
                                        If arraytext.Length <= 13 Then
                                            grasa = -1
                                            proteina = -1
                                            lactosa = -1
                                            st = -1
                                            If Trim(arraytext(11)) <> "" And Trim(arraytext(11)) <> "-" Then
                                                Try
                                                    rc = arraytext(11)
                                                Catch ex As Exception
                                                    MsgBox("Error en archivo: " & file.Name & ", línea: " & linea)
                                                End Try
                                            Else
                                                rc = -1
                                            End If
                                            crioscopia = -1
                                            urea = -1
                                            proteinav = -1
                                            caseina = -1
                                            densidad = -1
                                            ph = -1
                                        Else
                                            If Trim(arraytext(13)) = "" Or Trim(arraytext(13)) = "-" Then
                                                grasa = -1

                                            Else
                                                Try
                                                    grasa = arraytext(13)
                                                Catch ex As Exception
                                                    MsgBox("Error en archivo: " & file.Name & ", línea: " & linea & ", valor: Grasa")
                                                    Exit Sub
                                                End Try

                                            End If
                                            If Trim(arraytext(14)) = "" Or Trim(arraytext(14)) = "-" Then
                                                proteina = -1
                                            Else
                                                Try
                                                    proteina = arraytext(14)
                                                Catch ex As Exception
                                                    MsgBox("Error en archivo: " & file.Name & ", línea: " & linea & ", valor: Proteína")
                                                    Exit Sub
                                                End Try


                                            End If
                                            If Trim(arraytext(15)) = "" Or Trim(arraytext(15)) = "-" Then
                                                lactosa = -1
                                            Else
                                                Try
                                                    lactosa = arraytext(15)
                                                Catch ex As Exception
                                                    MsgBox("Error en archivo: " & file.Name & ", línea: " & linea & ", valor: Lactosa")
                                                    Exit Sub
                                                End Try


                                            End If
                                            If Trim(arraytext(16)) = "" Or Trim(arraytext(16)) = "-" Then
                                                st = -1
                                            Else
                                                Try
                                                    st = arraytext(16)
                                                Catch ex As Exception
                                                    MsgBox("Error en archivo: " & file.Name & ", línea: " & linea & ", valor: Sólidos totales")
                                                    Exit Sub
                                                End Try


                                            End If
                                            If Trim(arraytext(11)) = "" Or Trim(arraytext(11)) = "-" Then
                                                rc = -1

                                            Else
                                                Try
                                                    rc = arraytext(11)
                                                Catch ex As Exception
                                                    MsgBox("Error en archivo: " & file.Name & ", línea: " & linea & ", valor: RC")
                                                    Exit Sub
                                                End Try
                                            End If
                                            '** IMPORTAR CRIOSCOPIA **************************************************************************
                                            If Trim(arraytext(17)) = "" Or Trim(arraytext(17)) = "-" Then
                                                crioscopia = -1
                                            Else
                                                Try
                                                    crioscopia = arraytext(17)

                                                Catch ex As Exception
                                                    MsgBox("Error en archivo: " & file.Name & ", línea: " & linea & ", valor: Crioscopía")
                                                    Exit Sub
                                                End Try
                                            End If


                                            '***************************************************************************************************
                                            If Trim(arraytext(18)) = "" Or Trim(arraytext(18)) = "-" Then
                                                urea = -1
                                            Else
                                                Try
                                                    urea = arraytext(18)

                                                Catch ex As Exception
                                                    MsgBox("Error en archivo: " & file.Name & ", línea: " & linea & ", valor: Urea")
                                                    Exit Sub
                                                End Try

                                            End If
                                            If Trim(arraytext(28)) = "" Or Trim(arraytext(28)) = "-" Then
                                                proteinav = -1
                                            Else
                                                Try
                                                    proteinav = arraytext(28)

                                                Catch ex As Exception
                                                    MsgBox("Error en archivo: " & file.Name & ", línea: " & linea & ", valor: Proteína verdadera")
                                                    Exit Sub
                                                End Try


                                            End If
                                            If Trim(arraytext(29)) = "" Or Trim(arraytext(29)) = "-" Then
                                                caseina = -1

                                            Else
                                                Try
                                                    caseina = arraytext(29)
                                                Catch ex As Exception
                                                    MsgBox("Error en archivo: " & file.Name & ", línea: " & linea & ", valor: Caseína")
                                                    Exit Sub
                                                End Try

                                            End If
                                            If Trim(arraytext(30)) = "" Or Trim(arraytext(30)) = "-" Then
                                                densidad = -1

                                            Else
                                                Try
                                                    densidad = arraytext(30)
                                                Catch ex As Exception
                                                    MsgBox("Error en archivo: " & file.Name & ", línea: " & linea & ", valor: Densidad")
                                                    Exit Sub
                                                End Try

                                            End If
                                            If Trim(arraytext(36)) = "" Or Trim(arraytext(36)) = "-" Then
                                                ph = -1

                                            Else
                                                Try
                                                    ph = arraytext(36)
                                                Catch ex As Exception
                                                    MsgBox("Error en archivo: " & file.Name & ", línea: " & linea & ", valor: pH")
                                                    Exit Sub
                                                End Try

                                            End If
                                        End If


                                        ficha2 = Mid(file.Name, Len(file.Name) - 4, 1)
                                        ficha3 = Mid(file.Name, 1, 1)
                                        If ficha2 = "a" Or ficha2 = "A" Or ficha2 = "b" Or ficha2 = "B" Or ficha2 = "c" Or ficha2 = "C" Or ficha2 = "d" Or ficha2 = "D" Or ficha2 = "e" Or ficha2 = "E" Or ficha2 = "f" Or ficha2 = "F" Or ficha2 = "g" Or ficha2 = "G" Or ficha2 = "h" Or ficha2 = "H" Or ficha2 = "i" Or ficha2 = "I" Or ficha2 = "j" Or ficha2 = "J" Or ficha2 = "k" Or ficha2 = "K" Then
                                            ficha = Mid(file.Name, 1, Len(file.Name) - 5)
                                        Else
                                            ficha = Mid(file.Name, 1, Len(file.Name) - 4)
                                        End If
                                        If Mid(ficha, 1, 1) = "l" Or Mid(ficha, 1, 1) = "L" Then
                                            'Dim MyString As String = ficha
                                            'ficha3 = MyString.Remove(1, 1)
                                            Dim MyString As String = ficha
                                            Dim MyChar As Char() = {"l"c, "L"c}
                                            Dim NewString As String = MyString.TrimStart(MyChar)
                                            ficha3 = NewString
                                        Else
                                            ficha3 = ficha
                                        End If

                                        '**CONTROL DE CRIOSCOPIA *************************************************************************

                                        Dim cc As New dCrioscopia_Control
                                        Dim ficha_cc As Long = 0
                                        Dim muestra_cc As String = ""
                                        Dim res_delta As Integer = 0
                                        Dim res_crioscopo As Integer = 0
                                        Dim diferencia_cc As Integer = 0
                                        ficha_cc = ficha3
                                        muestra_cc = matricula
                                        cc.FICHA = ficha_cc
                                        cc.MUESTRA = muestra_cc
                                        cc = cc.buscarxfichaxmuestra
                                        If Not cc Is Nothing Then
                                            res_delta = cc.DELTA
                                            res_crioscopo = cc.CRIOSCOPO
                                            If res_delta > res_crioscopo Then
                                                diferencia_cc = res_delta - res_crioscopo
                                            Else
                                                diferencia_cc = res_crioscopo - res_delta
                                            End If
                                            If diferencia_cc > 5 Then
                                                crioscopia = res_crioscopo
                                            End If
                                        End If
                                        cc = Nothing
                                        ficha_cc = Nothing
                                        muestra_cc = Nothing
                                        res_delta = Nothing
                                        res_crioscopo = Nothing
                                        diferencia_cc = Nothing
                                        '*************************************************************************************************

                                        Dim fechaoriginal As Date = Now()
                                        Dim fecha As String
                                        fecha = Format(fechaoriginal, "yyyy-MM-dd")

                                        c.FICHA = ficha3
                                        c.FECHA = fecha
                                        c.EQUIPO = "delta"
                                        c.PRODUCTO = producto
                                        c.MUESTRA = matricula
                                        c.RC = rc
                                        c.GRASA = grasa
                                        c.PROTEINA = proteina
                                        c.LACTOSA = lactosa
                                        c.ST = st
                                        c.CRIOSCOPIA = crioscopia
                                        c.UREA = urea
                                        c.PROTEINAV = proteinav
                                        c.CASEINA = caseina
                                        c.DENSIDAD = densidad
                                        c.PH = ph
                                        c.guardar()
                                    End If
                                End If
                            End If
                            linea = linea + 1
                        Loop Until sLine Is Nothing
                        objReader.Close()
                    End If


                    '*** MOVER ARCHIVO ***********************************************************************
                    'Dim sArchivoOrigen As String = "d:\documentos\secretaria\analisis\leche\bentley-delta\pasados\calidad de leche\" & nombrearchivo
                    Dim sArchivoOrigen As String = "Y:\documentos\secretaria\analisis\leche\bentley-delta\Calidad de leche\" & nombrearchivo
                    'Dim sRutaDestino As String = "d:\documentos\secretaria\analisis\leche\bentley-delta\pasados\calidad de leche\pasados NET\" & nombrearchivo
                    Dim sRutaDestino As String = "Y:\documentos\secretaria\analisis\leche\bentley-delta\pasados\calidad de leche\pasados NET\" & nombrearchivo

                    Try
                        ' Mover el fichero.si existe lo sobreescribe  
                        My.Computer.FileSystem.MoveFile(sArchivoOrigen, _
                                                        sRutaDestino, _
                                                        True)
                        'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                        ' errores  
                    Catch ex As Exception
                        MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
                    End Try

                    '***********************************
                    'Insert tabla preinforme_calidad
                    Dim pi As New dPreinformes
                    Dim fechaactual As Date = Now()
                    Dim _fecha As String
                    _fecha = Format(fechaactual, "yyyy-MM-dd")
                    pi.FICHA = ficha3
                    pi = pi.buscar
                    If Not pi Is Nothing Then
                    Else
                        Dim pi2 As New dPreinformes
                        pi2.FICHA = ficha3
                        pi2.TIPO = 10
                        pi2.CREADO = 0
                        pi2.FECHA = _fecha
                        pi2.guardar()
                        pi2 = Nothing
                    End If
                    pi = Nothing

                    ' Grabar estado de la ficha
                    Dim est As New dEstados
                    est.FICHA = ficha3
                    est.ESTADO = 4
                    est.FECHA = _fecha
                    'est.guardar2()
                    est = Nothing
                    '****************************

                    'Dim pical As New dPreinformeCalidad
                    'Dim fechaactual As Date = Now()
                    'Dim _fecha As String
                    '_fecha = Format(fechaactual, "yyyy-MM-dd")
                    'pical.FICHA = ficha3
                    'pical = pical.buscar
                    'If Not pical Is Nothing Then
                    'Else
                    '    Dim pical2 As New dPreinformeCalidad
                    '    pical2.FICHA = ficha3
                    '    pical2.CREADO = 0
                    '    pical2.FECHA = _fecha
                    '    pical2.guardar()
                    '    pical2 = Nothing
                    'End If
                    'pical = Nothing

                    '**********************************
                End If 'fin de control si archivoes de delta 400
            Next
        End If
    End Sub
    Private Sub controllecherocsv2()
        Dim extension As String
        Dim nombrearchivo As String = ""
        Dim linea As Integer
        Dim folder As New DirectoryInfo("Y:\documentos\secretaria\analisis\leche\bentley-delta\Control lechero")
        Dim _ficheros() As String
        _ficheros = Directory.GetFiles("c:\delta2")
        If Not (_ficheros.Length > 0) Then
        Else
            For Each file As FileInfo In folder.GetFiles("*.csv")
                nombrearchivo = file.Name
                If nombrearchivo.Length > 12 Then 'controlo si el archivo es de delta nuevo
                    linea = 1
                    extension = Microsoft.VisualBasic.Right(file.Name, 3)
                    Dim objReader As New StreamReader("Y:\documentos\secretaria\analisis\leche\bentley-delta\Control lechero\" & file.Name)
                    Dim sLine As String = ""
                    Dim arraytext() As String
                    Dim matricula As String = ""
                    Dim grasa As Double = 0
                    Dim proteina As Double = 0
                    Dim lactosa As Double = 0
                    Dim st As Double = 0
                    Dim rc As Integer = 0
                    Dim ficha As String = ""
                    Dim ficha2 As String = ""
                    Dim ficha3 As String = ""
                    Dim equipo As String = ""
                    Dim producto As String = ""
                    Dim crioscopia As Integer = 0
                    Dim urea As Integer = 0
                    Dim proteinav As Double = 0
                    Dim caseina As Double = 0
                    Dim densidad As Double = 0
                    Dim ph As Double = 0
                    Dim grasa_b As Double = 0
                    Dim grasa_a As Double = 0
                    Dim cit As Integer = 0
                    Dim agl As Double = 0
                    Dim sng As Double = 0
                    Dim sfa As Double = 0
                    Dim ufa As Double = 0
                    Dim mufa As Double = 0
                    Dim pufa As Double = 0
                    Dim c16 As Double = 0
                    Dim c180 As Double = 0
                    Dim c181 As Double = 0
                    Dim bhb As Double = 0
                    Dim acetone As Double = 0
                    Dim cisfat As Double = 0
                    Dim transfat As Double = 0
                    Dim denovofa As Double = 0
                    Dim mixedfa As Double = 0
                    Dim preformedfa As Double = 0
                    Dim denovofa2 As Double = 0
                    Dim mixedfa2 As Double = 0
                    Dim preformedfa2 As Double = 0
                    Dim nefa As Double = 0
                    ' *** SI EL ARCHIVO ES CSV **************************************************************************************
                    If extension = "csv" Or extension = "CSV" Then
                        Dim c As New dImpControl()
                        Dim ca As New dControlAux
                        Dim sa As New dSolicitudAnalisis
                        Dim p As New dCliente
                        Do
                            sLine = objReader.ReadLine()
                            If sLine <> " " Then
                                If linea = 3 Then
                                    arraytext = Split(sLine, ";")
                                    If arraytext.Length < 11 Then
                                        arraytext = Split(sLine, ",")
                                    End If
                                    producto = Trim(arraytext(10))
                                End If
                                If Not sLine Is Nothing Then
                                    If linea >= 8 Then
                                        arraytext = Split(sLine, ";")
                                        If arraytext.Length < 39 Then
                                            arraytext = Split(sLine, ",")
                                        End If
                                        matricula = Trim(arraytext(5))
                                        If arraytext.Length <= 13 Then
                                            grasa = -1
                                            proteina = -1
                                            lactosa = -1
                                            st = -1
                                            If Trim(arraytext(11)) <> "" And Trim(arraytext(11)) <> "-" Then
                                                Try
                                                    rc = arraytext(11)
                                                Catch ex As Exception
                                                    MsgBox("Error en archivo: " & file.Name & ", línea: " & linea)
                                                End Try
                                            Else
                                                rc = -1
                                            End If
                                            crioscopia = -1
                                            urea = -1
                                            proteinav = -1
                                            caseina = -1
                                            densidad = -1
                                            ph = -1
                                        Else
                                            If Trim(arraytext(13)) = "" Or Trim(arraytext(13)) = "-" Then
                                                grasa = -1
                                            Else
                                                Try
                                                    grasa = arraytext(13)
                                                Catch ex As Exception
                                                    MsgBox("Error en archivo: " & file.Name & ", línea: " & linea & ", valor: Grasa")
                                                    Exit Sub
                                                End Try
                                            End If
                                            If Trim(arraytext(14)) = "" Or Trim(arraytext(14)) = "-" Then
                                                proteina = -1
                                            Else
                                                Try
                                                    proteina = arraytext(14)
                                                Catch ex As Exception
                                                    MsgBox("Error en archivo: " & file.Name & ", línea: " & linea & ", valor: Proteína")
                                                    Exit Sub
                                                End Try
                                            End If
                                            If Trim(arraytext(15)) = "" Or Trim(arraytext(15)) = "-" Then
                                                lactosa = -1
                                            Else
                                                Try
                                                    lactosa = arraytext(15)
                                                Catch ex As Exception
                                                    MsgBox("Error en archivo: " & file.Name & ", línea: " & linea & ", valor: Lactosa")
                                                    Exit Sub
                                                End Try
                                            End If
                                            If Trim(arraytext(16)) = "" Or Trim(arraytext(16)) = "-" Then
                                                st = -1
                                            Else
                                                Try
                                                    st = arraytext(16)
                                                Catch ex As Exception
                                                    MsgBox("Error en archivo: " & file.Name & ", línea: " & linea & ", valor: Sólidos totales")
                                                    Exit Sub
                                                End Try
                                            End If
                                            If Trim(arraytext(11)) = "" Or Trim(arraytext(11)) = "-" Then
                                                rc = -1
                                            Else
                                                Try
                                                    rc = arraytext(11)
                                                Catch ex As Exception
                                                    MsgBox("Error en archivo: " & file.Name & ", línea: " & linea & ", valor: RC")
                                                    Exit Sub
                                                End Try
                                            End If
                                            '** IMPORTAR CRIOSCOPIA **************************************************************************
                                            If Trim(arraytext(17)) = "" Or Trim(arraytext(17)) = "-" Then
                                                crioscopia = -1
                                            Else
                                                Try
                                                    crioscopia = arraytext(17)
                                                Catch ex As Exception
                                                    MsgBox("Error en archivo: " & file.Name & ", línea: " & linea & ", valor: Crioscopía")
                                                    Exit Sub
                                                End Try
                                            End If
                                            '***************************************************************************************************
                                            If Trim(arraytext(18)) = "" Or Trim(arraytext(18)) = "-" Then
                                                urea = -1
                                            Else
                                                Try
                                                    urea = arraytext(18)
                                                Catch ex As Exception
                                                    MsgBox("Error en archivo: " & file.Name & ", línea: " & linea & ", valor: Urea")
                                                    Exit Sub
                                                End Try
                                            End If
                                            If Trim(arraytext(28)) = "" Or Trim(arraytext(28)) = "-" Then
                                                proteinav = -1
                                            Else
                                                Try
                                                    proteinav = arraytext(28)
                                                Catch ex As Exception
                                                    MsgBox("Error en archivo: " & file.Name & ", línea: " & linea & ", valor: Proteína verdadera")
                                                    Exit Sub
                                                End Try
                                            End If
                                            If Trim(arraytext(29)) = "" Or Trim(arraytext(29)) = "-" Then
                                                caseina = -1
                                            Else
                                                Try
                                                    caseina = arraytext(29)
                                                Catch ex As Exception
                                                    MsgBox("Error en archivo: " & file.Name & ", línea: " & linea & ", valor: Caseína")
                                                    Exit Sub
                                                End Try
                                            End If
                                            If Trim(arraytext(30)) = "" Or Trim(arraytext(30)) = "-" Then
                                                densidad = -1
                                            Else
                                                Try
                                                    densidad = arraytext(30)
                                                Catch ex As Exception
                                                    MsgBox("Error en archivo: " & file.Name & ", línea: " & linea & ", valor: Densidad")
                                                    Exit Sub
                                                End Try
                                            End If
                                            If Trim(arraytext(36)) = "" Or Trim(arraytext(36)) = "-" Then
                                                ph = -1
                                            Else
                                                Try
                                                    ph = arraytext(36)
                                                Catch ex As Exception
                                                    MsgBox("Error en archivo: " & file.Name & ", línea: " & linea & ", valor: pH")
                                                    Exit Sub
                                                End Try
                                            End If
                                        End If
                                        ficha2 = Mid(file.Name, Len(file.Name) - 4, 1)
                                        ficha3 = Mid(file.Name, 1, 1)
                                        If ficha2 = "a" Or ficha2 = "A" Or ficha2 = "b" Or ficha2 = "B" Or ficha2 = "c" Or ficha2 = "C" Or ficha2 = "d" Or ficha2 = "D" Or ficha2 = "e" Or ficha2 = "E" Or ficha2 = "f" Or ficha2 = "F" Or ficha2 = "g" Or ficha2 = "G" Or ficha2 = "h" Or ficha2 = "H" Or ficha2 = "i" Or ficha2 = "I" Or ficha2 = "j" Or ficha2 = "J" Or ficha2 = "k" Or ficha2 = "K" Then
                                            ficha = Mid(file.Name, 1, Len(file.Name) - 5)
                                        Else
                                            ficha = Mid(file.Name, 1, Len(file.Name) - 4)
                                        End If
                                        If Mid(ficha, 1, 1) = "l" Or Mid(ficha, 1, 1) = "L" Then
                                            Dim MyString As String = ficha
                                            Dim MyChar As Char() = {"l"c, "L"c}
                                            Dim NewString As String = MyString.TrimStart(MyChar)
                                            ficha3 = NewString
                                        Else
                                            ficha3 = ficha
                                        End If
                                        '**CONTROL DE CRIOSCOPIA *************************************************************************
                                        Dim cc As New dCrioscopia_Control
                                        Dim ficha_cc As Long = 0
                                        Dim muestra_cc As String = ""
                                        Dim res_delta As Integer = 0
                                        Dim res_crioscopo As Integer = 0
                                        Dim diferencia_cc As Integer = 0
                                        ficha_cc = ficha3
                                        muestra_cc = matricula
                                        cc.FICHA = ficha_cc
                                        cc.MUESTRA = muestra_cc
                                        cc = cc.buscarxfichaxmuestra
                                        If Not cc Is Nothing Then
                                            res_delta = cc.DELTA
                                            res_crioscopo = cc.CRIOSCOPO
                                            If res_delta > res_crioscopo Then
                                                diferencia_cc = res_delta - res_crioscopo
                                            Else
                                                diferencia_cc = res_crioscopo - res_delta
                                            End If
                                            If diferencia_cc > 5 Then
                                                crioscopia = res_crioscopo
                                            End If
                                        End If
                                        cc = Nothing
                                        ficha_cc = Nothing
                                        muestra_cc = Nothing
                                        res_delta = Nothing
                                        res_crioscopo = Nothing
                                        diferencia_cc = Nothing
                                        '*************************************************************************************************
                                        Dim fechaoriginal As Date = Now()
                                        Dim fecha As String
                                        fecha = Format(fechaoriginal, "yyyy-MM-dd")

                                        c.FICHA = ficha3
                                        c.FECHA = fecha
                                        c.EQUIPO = "delta"
                                        c.PRODUCTO = producto
                                        c.MUESTRA = matricula
                                        c.RC = rc
                                        c.GRASA = grasa
                                        c.PROTEINA = proteina
                                        c.LACTOSA = lactosa
                                        c.ST = st
                                        c.CRIOSCOPIA = crioscopia
                                        c.UREA = urea
                                        c.PROTEINAV = proteinav
                                        c.CASEINA = caseina
                                        c.DENSIDAD = densidad
                                        c.PH = ph
                                        c.guardar()
                                        ca.FICHA = ficha3
                                        ca.FECHA = fecha
                                        sa.ID = ficha3
                                        sa = sa.buscar
                                        ca.PRODUCTOR = sa.IDPRODUCTOR
                                        ca.MUESTRA = matricula
                                        ca.RC = rc
                                        ca.TAMBO = sa.TAMBO
                                        ca.guardar()
                                    End If
                                End If
                            End If
                            linea = linea + 1
                        Loop Until sLine Is Nothing
                        objReader.Close()
                    End If


                    '*** MOVER ARCHIVO ***********************************************************************
                    Dim sArchivoOrigen As String = "Y:\documentos\secretaria\analisis\leche\bentley-delta\Control lechero\" & nombrearchivo
                    Dim sRutaDestino As String = "Y:\documentos\secretaria\analisis\leche\bentley-delta\pasados\control lechero\pasados NET\" & nombrearchivo
                    Try
                        ' Mover el fichero.si existe lo sobreescribe  
                        My.Computer.FileSystem.MoveFile(sArchivoOrigen, _
                                                        sRutaDestino, _
                                                        True)
                        'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                        ' errores  
                    Catch ex As Exception
                        MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
                    End Try
                    '***********************************
                    'Insert tabla preinforme_calidad
                    Dim pi As New dPreinformes
                    Dim fechaactual As Date = Now()
                    Dim _fecha As String
                    _fecha = Format(fechaactual, "yyyy-MM-dd")
                    pi.FICHA = ficha3
                    pi = pi.buscar
                    If Not pi Is Nothing Then
                    Else
                        Dim pi2 As New dPreinformes
                        pi2.FICHA = ficha3
                        pi2.TIPO = 1
                        pi2.CREADO = 0
                        pi2.FECHA = _fecha
                        pi2.guardar()
                        pi2 = Nothing
                    End If
                    pi = Nothing
                    ' Grabar estado de la ficha
                    Dim est As New dEstados
                    est.FICHA = ficha3
                    est.ESTADO = 4
                    est.FECHA = _fecha
                    'est.guardar2()
                    est = Nothing
                    '****************************
                End If 'fin de control archivo delta nuevo
            Next
        End If
    End Sub
    Private Sub calidadcsv2()
        Dim extension As String
        Dim nombrearchivo As String = ""
        Dim linea As Integer
        Dim folder As New DirectoryInfo("Y:\Documentos\SECRETARIA\Analisis\Leche\Bentley-delta\Calidad de leche")
        Dim _ficheros() As String
        _ficheros = Directory.GetFiles("Y:\Documentos\SECRETARIA\Analisis\Leche\Bentley-delta\Calidad de leche")
        If Not (_ficheros.Length > 0) Then
        Else
            For Each file As FileInfo In folder.GetFiles("*.csv")
                nombrearchivo = file.Name
                If nombrearchivo.Length > 12 Then 'controlo si el archivo es de delta nuevo
                    linea = 1
                    extension = Microsoft.VisualBasic.Right(file.Name, 3)
                    Dim objReader As New StreamReader("Y:\documentos\secretaria\analisis\leche\bentley-delta\Calidad de leche\" & file.Name)
                    Dim sLine As String = ""
                    Dim arraytext() As String
                    Dim matricula As String = ""
                    Dim grasa As Double = 0
                    Dim proteina As Double = 0
                    Dim lactosa As Double = 0
                    Dim st As Double = 0
                    Dim rc As Integer = 0
                    Dim ficha As String = ""
                    Dim ficha2 As String = ""
                    Dim ficha3 As String = ""
                    Dim equipo As String = ""
                    Dim producto As String = ""
                    Dim crioscopia As Integer = 0
                    Dim urea As Integer = 0
                    Dim proteinav As Double = 0
                    Dim caseina As Double = 0
                    Dim densidad As Double = 0
                    Dim ph As Double = 0
                    Dim grasa_b As Double = 0
                    Dim grasa_a As Double = 0
                    Dim cit As Integer = 0
                    Dim agl As Double = 0
                    Dim sng As Double = 0
                    Dim sfa As Double = 0
                    Dim ufa As Double = 0
                    Dim mufa As Double = 0
                    Dim pufa As Double = 0
                    Dim c16 As Double = 0
                    Dim c180 As Double = 0
                    Dim c181 As Double = 0
                    Dim bhb As Double = 0
                    Dim acetone As Double = 0
                    Dim cisfat As Double = 0
                    Dim transfat As Double = 0
                    Dim denovofa As Double = 0
                    Dim mixedfa As Double = 0
                    Dim preformedfa As Double = 0
                    Dim denovofa2 As Double = 0
                    Dim mixedfa2 As Double = 0
                    Dim preformedfa2 As Double = 0
                    Dim nefa As Double = 0

                    ' *** SI EL ARCHIVO ES CSV **************************************************************************************
                    If extension = "csv" Or extension = "CSV" Then
                        Dim c As New dImpCalidad()
                        Do
                            sLine = objReader.ReadLine()
                            If sLine <> " " Then
                                If linea = 3 Then
                                    arraytext = Split(sLine, ";")
                                    If arraytext.Length < 11 Then
                                        arraytext = Split(sLine, ",")
                                    End If
                                    producto = Trim(arraytext(10))
                                End If
                                If Not sLine Is Nothing Then
                                    If linea >= 8 Then
                                        arraytext = Split(sLine, ";")
                                        If arraytext.Length < 39 Then
                                            arraytext = Split(sLine, ",")
                                        End If
                                        matricula = Trim(arraytext(5))
                                        If arraytext.Length <= 13 Then
                                            grasa = -1
                                            proteina = -1
                                            lactosa = -1
                                            st = -1
                                            If Trim(arraytext(11)) <> "" And Trim(arraytext(11)) <> "-" Then
                                                Try
                                                    rc = arraytext(11)
                                                Catch ex As Exception
                                                    MsgBox("Error en archivo: " & file.Name & ", línea: " & linea)
                                                End Try
                                            Else
                                                rc = -1
                                            End If
                                            crioscopia = -1
                                            urea = -1
                                            proteinav = -1
                                            caseina = -1
                                            densidad = -1
                                            ph = -1
                                        Else
                                            If Trim(arraytext(13)) = "" Or Trim(arraytext(13)) = "-" Then
                                                grasa = -1
                                            Else
                                                Try
                                                    grasa = arraytext(13)
                                                Catch ex As Exception
                                                    MsgBox("Error en archivo: " & file.Name & ", línea: " & linea & ", valor: Grasa")
                                                    Exit Sub
                                                End Try
                                            End If
                                            If Trim(arraytext(14)) = "" Or Trim(arraytext(14)) = "-" Then
                                                proteina = -1
                                            Else
                                                Try
                                                    proteina = arraytext(14)
                                                Catch ex As Exception
                                                    MsgBox("Error en archivo: " & file.Name & ", línea: " & linea & ", valor: Proteína")
                                                    Exit Sub
                                                End Try
                                            End If
                                            If Trim(arraytext(15)) = "" Or Trim(arraytext(15)) = "-" Then
                                                lactosa = -1
                                            Else
                                                Try
                                                    lactosa = arraytext(15)
                                                Catch ex As Exception
                                                    MsgBox("Error en archivo: " & file.Name & ", línea: " & linea & ", valor: Lactosa")
                                                    Exit Sub
                                                End Try
                                            End If
                                            If Trim(arraytext(16)) = "" Or Trim(arraytext(16)) = "-" Then
                                                st = -1
                                            Else
                                                Try
                                                    st = arraytext(16)
                                                Catch ex As Exception
                                                    MsgBox("Error en archivo: " & file.Name & ", línea: " & linea & ", valor: Sólidos totales")
                                                    Exit Sub
                                                End Try
                                            End If
                                            If Trim(arraytext(11)) = "" Or Trim(arraytext(11)) = "-" Then
                                                rc = -1
                                            Else
                                                Try
                                                    rc = arraytext(11)
                                                Catch ex As Exception
                                                    MsgBox("Error en archivo: " & file.Name & ", línea: " & linea & ", valor: RC")
                                                    Exit Sub
                                                End Try
                                            End If
                                            '** IMPORTAR CRIOSCOPIA **************************************************************************
                                            If Trim(arraytext(17)) = "" Or Trim(arraytext(17)) = "-" Then
                                                crioscopia = -1
                                            Else
                                                Try
                                                    crioscopia = arraytext(17)
                                                Catch ex As Exception
                                                    MsgBox("Error en archivo: " & file.Name & ", línea: " & linea & ", valor: Crioscopía")
                                                    Exit Sub
                                                End Try
                                            End If
                                            '***************************************************************************************************
                                            If Trim(arraytext(18)) = "" Or Trim(arraytext(18)) = "-" Then
                                                urea = -1
                                            Else
                                                Try
                                                    urea = arraytext(18)

                                                Catch ex As Exception
                                                    MsgBox("Error en archivo: " & file.Name & ", línea: " & linea & ", valor: Urea")
                                                    Exit Sub
                                                End Try
                                            End If
                                            If Trim(arraytext(28)) = "" Or Trim(arraytext(28)) = "-" Then
                                                proteinav = -1
                                            Else
                                                Try
                                                    proteinav = arraytext(28)
                                                Catch ex As Exception
                                                    MsgBox("Error en archivo: " & file.Name & ", línea: " & linea & ", valor: Proteína verdadera")
                                                    Exit Sub
                                                End Try
                                            End If
                                            If Trim(arraytext(29)) = "" Or Trim(arraytext(29)) = "-" Then
                                                caseina = -1
                                            Else
                                                Try
                                                    caseina = arraytext(29)
                                                Catch ex As Exception
                                                    MsgBox("Error en archivo: " & file.Name & ", línea: " & linea & ", valor: Caseína")
                                                    Exit Sub
                                                End Try
                                            End If
                                            If Trim(arraytext(30)) = "" Or Trim(arraytext(30)) = "-" Then
                                                densidad = -1
                                            Else
                                                Try
                                                    densidad = arraytext(30)
                                                Catch ex As Exception
                                                    MsgBox("Error en archivo: " & file.Name & ", línea: " & linea & ", valor: Densidad")
                                                    Exit Sub
                                                End Try
                                            End If
                                            If Trim(arraytext(36)) = "" Or Trim(arraytext(36)) = "-" Then
                                                ph = -1
                                            Else
                                                Try
                                                    ph = arraytext(36)
                                                Catch ex As Exception
                                                    MsgBox("Error en archivo: " & file.Name & ", línea: " & linea & ", valor: pH")
                                                    Exit Sub
                                                End Try
                                            End If
                                        End If
                                        ficha2 = Mid(file.Name, Len(file.Name) - 4, 1)
                                        ficha3 = Mid(file.Name, 1, 1)
                                        If ficha2 = "a" Or ficha2 = "A" Or ficha2 = "b" Or ficha2 = "B" Or ficha2 = "c" Or ficha2 = "C" Or ficha2 = "d" Or ficha2 = "D" Or ficha2 = "e" Or ficha2 = "E" Or ficha2 = "f" Or ficha2 = "F" Or ficha2 = "g" Or ficha2 = "G" Or ficha2 = "h" Or ficha2 = "H" Or ficha2 = "i" Or ficha2 = "I" Or ficha2 = "j" Or ficha2 = "J" Or ficha2 = "k" Or ficha2 = "K" Then
                                            ficha = Mid(file.Name, 1, Len(file.Name) - 5)
                                        Else
                                            ficha = Mid(file.Name, 1, Len(file.Name) - 4)
                                        End If
                                        If Mid(ficha, 1, 1) = "l" Or Mid(ficha, 1, 1) = "L" Then
                                            Dim MyString As String = ficha
                                            Dim MyChar As Char() = {"l"c, "L"c}
                                            Dim NewString As String = MyString.TrimStart(MyChar)
                                            ficha3 = NewString
                                        Else
                                            ficha3 = ficha
                                        End If
                                        '**CONTROL DE CRIOSCOPIA *************************************************************************
                                        Dim cc As New dCrioscopia_Control
                                        Dim ficha_cc As Long = 0
                                        Dim muestra_cc As String = ""
                                        Dim res_delta As Integer = 0
                                        Dim res_crioscopo As Integer = 0
                                        Dim diferencia_cc As Integer = 0
                                        ficha_cc = ficha3
                                        muestra_cc = matricula
                                        cc.FICHA = ficha_cc
                                        cc.MUESTRA = muestra_cc
                                        cc = cc.buscarxfichaxmuestra
                                        If Not cc Is Nothing Then
                                            res_delta = cc.DELTA
                                            res_crioscopo = cc.CRIOSCOPO
                                            If res_delta > res_crioscopo Then
                                                diferencia_cc = res_delta - res_crioscopo
                                            Else
                                                diferencia_cc = res_crioscopo - res_delta
                                            End If
                                            If diferencia_cc > 5 Then
                                                crioscopia = res_crioscopo
                                            End If
                                        End If
                                        cc = Nothing
                                        ficha_cc = Nothing
                                        muestra_cc = Nothing
                                        res_delta = Nothing
                                        res_crioscopo = Nothing
                                        diferencia_cc = Nothing
                                        '*************************************************************************************************
                                        Dim fechaoriginal As Date = Now()
                                        Dim fecha As String
                                        fecha = Format(fechaoriginal, "yyyy-MM-dd")
                                        c.FICHA = ficha3
                                        c.FECHA = fecha
                                        c.EQUIPO = "delta2"
                                        c.PRODUCTO = producto
                                        c.MUESTRA = matricula
                                        c.RC = rc
                                        c.GRASA = grasa
                                        c.PROTEINA = proteina
                                        c.LACTOSA = lactosa
                                        c.ST = st
                                        c.CRIOSCOPIA = crioscopia
                                        c.UREA = urea
                                        c.PROTEINAV = proteinav
                                        c.CASEINA = caseina
                                        c.DENSIDAD = densidad
                                        c.PH = ph
                                        c.guardar()
                                    End If
                                End If
                            End If
                            linea = linea + 1
                        Loop Until sLine Is Nothing
                        objReader.Close()
                    End If

                    '*** MOVER ARCHIVO ***********************************************************************
                    Dim sArchivoOrigen As String = "Y:\documentos\secretaria\analisis\leche\bentley-delta\Calidad de leche\" & nombrearchivo
                    Dim sRutaDestino As String = "Y:\documentos\secretaria\analisis\leche\bentley-delta\pasados\calidad de leche\pasados NET\" & nombrearchivo
                    Try
                        ' Mover el fichero.si existe lo sobreescribe  
                        My.Computer.FileSystem.MoveFile(sArchivoOrigen, _
                                                        sRutaDestino, _
                                                        True)
                        'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                        ' errores  
                    Catch ex As Exception
                        MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
                    End Try

                    '***********************************
                    'Insert tabla preinforme_calidad
                    Dim pi As New dPreinformes
                    Dim fechaactual As Date = Now()
                    Dim _fecha As String
                    _fecha = Format(fechaactual, "yyyy-MM-dd")
                    pi.FICHA = ficha3
                    pi = pi.buscar
                    If Not pi Is Nothing Then
                    Else
                        Dim pi2 As New dPreinformes
                        pi2.FICHA = ficha3
                        pi2.TIPO = 10
                        pi2.CREADO = 0
                        pi2.FECHA = _fecha
                        pi2.guardar()
                        pi2 = Nothing
                    End If
                    pi = Nothing
                    ' Grabar estado de la ficha
                    Dim est As New dEstados
                    est.FICHA = ficha3
                    est.ESTADO = 4
                    est.FECHA = _fecha
                    'est.guardar2()
                    est = Nothing
                    '****************************
                End If 'fin de control archivo delta nuevo
            Next
        End If
    End Sub
    Private Sub calidadxls()
        Dim extension As String
        Dim nombrearchivo As String = ""
        Dim linea As Integer
        'Dim folder As New DirectoryInfo("d:\documentos\secretaria\analisis\leche\bentley-delta\pasados\calidad de leche")
        Dim folder As New DirectoryInfo("Y:\documentos\secretaria\analisis\leche\bentley-delta\Calidad de leche")
        'Dim folder As New DirectoryInfo("\\192.168.1.10\E\documentos\secretaria\resultados informes 2012")

        ' For Each file As FileInfo In folder.GetFiles("*.xls, *.CSV, *.fat")
        For Each file As FileInfo In folder.GetFiles("*.xls")
            'ListBox1.Items.Add(file.Name)
            nombrearchivo = file.Name
            linea = 1
            extension = Microsoft.VisualBasic.Right(file.Name, 3)
            'Dim objReader As New StreamReader("d:\documentos\secretaria\analisis\leche\bentley-delta\pasados\calidad de leche\" & file.Name)
            Dim objReader As New StreamReader("Y:\documentos\secretaria\analisis\leche\bentley-delta\Calidad de leche\" & file.Name)
            Dim sLine As String = ""
            'Dim arrText As New ArrayList()
            ''Dim arraytext() As String

            Dim matricula As String = ""
            Dim grasa As Double = 0
            Dim proteina As Double = 0
            Dim lactosa As Double = 0
            Dim st As Double = 0
            Dim rc As Integer = 0
            Dim ficha As String = ""
            Dim ficha2 As String = ""
            Dim ficha3 As String = ""
            Dim equipo As String = ""
            Dim producto As String = ""
            Dim crioscopia As Integer = 0
            Dim urea As Integer = 0
            Dim proteinav As Double = 0
            Dim caseina As Double = 0
            Dim densidad As Double = 0
            Dim ph As Double = 0

            ' *** SI EL ARCHIVO ES XLS **************************************************************************************
            If extension = "xls" Or extension = "XLS" Then
                Dim c As New dImpCalidad()
                Dim Arch As String, CantFilas As Integer
                Arch = "Y:\documentos\secretaria\analisis\leche\bentley-delta\Calidad de leche\" & file.Name
                Dim x1app As Microsoft.Office.Interop.Excel.Application
                Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
                Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
                x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
                x1libro = CType(x1app.Workbooks.Open(Arch), Microsoft.Office.Interop.Excel.Workbook)
                x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)
                Dim bandera As Integer = 0

                CantFilas = x1app.Range("a1").CurrentRegion.Rows.Count

                ficha2 = Mid(file.Name, Len(file.Name) - 4, 1)
                ficha3 = Mid(file.Name, 1, 1)
                If ficha2 = "a" Or ficha2 = "A" Or ficha2 = "b" Or ficha2 = "B" Or ficha2 = "c" Or ficha2 = "C" Or ficha2 = "d" Or ficha2 = "D" Then
                    ficha = Mid(file.Name, 1, Len(file.Name) - 5)
                Else
                    ficha = Mid(file.Name, 1, Len(file.Name) - 4)
                End If
                If Mid(ficha, 1, 1) = "l" Or Mid(ficha, 1, 1) = "L" Then
                    'Dim MyString As String = ficha
                    'ficha3 = MyString.Remove(1, 1)
                    Dim MyString As String = ficha
                    Dim MyChar As Char() = {"l"c, "L"c}
                    Dim NewString As String = MyString.TrimStart(MyChar)
                    ficha3 = NewString
                Else
                    ficha3 = ficha
                End If
                Dim fechaoriginal As Date = Now()
                Dim fecha As String
                fecha = Format(fechaoriginal, "yyyy-MM-dd")

                For i = 1 To CantFilas
                    If Trim(x1hoja.Cells(i, 2).formula) <> "" Then
                        matricula = Trim(x1hoja.Cells(i, 2).value)
                    Else
                        matricula = -1
                    End If
                    If Trim(x1hoja.Cells(i, 3).formula) <> "" Then
                        Try
                            grasa = x1hoja.Cells(i, 3).value
                        Catch ex As Exception
                            MsgBox("Error en archivo: " & file.Name & ", línea: " & i & ", valor: Grasa")
                            Exit Sub
                        End Try

                    Else
                        grasa = -1
                    End If
                    If Trim(x1hoja.Cells(i, 4).formula) <> "" Then
                        Try
                            proteina = x1hoja.Cells(i, 4).value
                            bandera = 1
                        Catch ex As Exception
                            MsgBox("Error en archivo: " & file.Name & ", línea: " & i & ", valor: Proteína")
                            Exit Sub
                        End Try

                    Else
                        proteina = -1
                    End If
                    If Trim(x1hoja.Cells(i, 5).formula) <> "" Then
                        Try
                            lactosa = x1hoja.Cells(i, 5).value
                        Catch ex As Exception
                            MsgBox("Error en archivo: " & file.Name & ", línea: " & i & ", valor: Lactosa")
                            Exit Sub
                        End Try

                    Else
                        lactosa = -1
                    End If
                    If Trim(x1hoja.Cells(i, 6).formula) <> "" Then
                        Try
                            st = x1hoja.Cells(i, 6).value
                        Catch ex As Exception
                            MsgBox("Error en archivo: " & file.Name & ", línea: " & i & ", valor: Sólidos totales")
                            Exit Sub
                        End Try

                    Else
                        st = -1
                    End If
                    If Trim(x1hoja.Cells(i, 7).formula) <> "" Then
                        Try
                            rc = x1hoja.Cells(i, 7).value
                        Catch ex As Exception
                            MsgBox("Error en archivo: " & file.Name & ", línea: " & i & ", valor: RC")
                            Exit Sub
                        End Try

                    Else
                        rc = -1
                    End If

                    If bandera = 0 Then
                        c.FICHA = ficha3
                        c.FECHA = fecha
                        c.EQUIPO = "bentley"
                        c.PRODUCTO = "leche"
                        c.MUESTRA = matricula
                        c.RC = grasa
                        c.GRASA = -1
                        c.PROTEINA = proteina
                        c.LACTOSA = lactosa
                        c.ST = st
                        c.CRIOSCOPIA = -1
                        c.UREA = -1
                        c.PROTEINAV = -1
                        c.CASEINA = -1
                        c.DENSIDAD = -1
                        c.PH = -1
                        c.guardar()
                    ElseIf bandera = 1 Then
                        c.FICHA = ficha3
                        c.FECHA = fecha
                        c.EQUIPO = "bentley"
                        c.PRODUCTO = "leche"
                        c.MUESTRA = matricula
                        c.RC = rc
                        c.GRASA = grasa
                        c.PROTEINA = proteina
                        c.LACTOSA = lactosa
                        c.ST = st
                        c.CRIOSCOPIA = -1
                        c.UREA = -1
                        c.PROTEINAV = -1
                        c.CASEINA = -1
                        c.DENSIDAD = -1
                        c.PH = -1
                        c.guardar()
                    End If
                Next

                ' Cierro Excel
                x1libro.Close()
                x1app = Nothing
                x1libro = Nothing
                x1hoja = Nothing
                objReader.Close()

                Dim proceso As System.Diagnostics.Process()
                proceso = System.Diagnostics.Process.GetProcessesByName("EXCEL")

                For Each opro As System.Diagnostics.Process In proceso
                    'antes de iniciar el proceso obtengo la fecha en que inicie el 
                    'proceso para detener todos los procesos que excel que inicio
                    'mi código durante el proceso
                    opro.Kill()

                Next

            End If

            '*** MOVER ARCHIVO ***********************************************************************
            'Dim sArchivoOrigen As String = "d:\documentos\secretaria\analisis\leche\bentley-delta\pasados\calidad de leche\" & nombrearchivo
            Dim sArchivoOrigen As String = "Y:\documentos\secretaria\analisis\leche\bentley-delta\Calidad de leche\" & nombrearchivo
            'Dim sRutaDestino As String = "d:\documentos\secretaria\analisis\leche\bentley-delta\pasados\calidad de leche\pasados NET\" & nombrearchivo
            Dim sRutaDestino As String = "Y:\documentos\secretaria\analisis\leche\bentley-delta\pasados\calidad de leche\pasados NET\" & nombrearchivo

            Try
                ' Mover el fichero.si existe lo sobreescribe  
                My.Computer.FileSystem.MoveFile(sArchivoOrigen, _
                                                sRutaDestino, _
                                                True)
                'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                ' errores  
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try

            '***********************************
            'Insert tabla preinforme_calidad
            Dim pi As New dPreinformes
            Dim fechaactual As Date = Now()
            Dim _fecha As String
            _fecha = Format(fechaactual, "yyyy-MM-dd")
            pi.FICHA = ficha3
            pi = pi.buscar
            If Not pi Is Nothing Then
            Else
                Dim pi2 As New dPreinformes
                pi2.FICHA = ficha3
                pi2.TIPO = 10
                pi2.CREADO = 0
                pi2.FECHA = _fecha
                pi2.guardar()
                pi2 = Nothing
            End If
            pi = Nothing

            ' Grabar estado de la ficha
            Dim est As New dEstados
            est.FICHA = ficha3
            est.ESTADO = 4
            est.FECHA = _fecha
            'est.guardar2()
            est = Nothing
            '****************************

            'Dim pical As New dPreinformeCalidad
            'Dim fechaactual As Date = Now()
            'Dim _fecha As String
            '_fecha = Format(fechaactual, "yyyy-MM-dd")
            'pical.FICHA = ficha3
            'pical = pical.buscar
            'If Not pical Is Nothing Then
            'Else
            '    Dim pical2 As New dPreinformeCalidad
            '    pical2.FICHA = ficha3
            '    pical2.CREADO = 0
            '    pical2.FECHA = _fecha
            '    pical2.guardar()
            '    pical2 = Nothing
            'End If
            'pical = Nothing
            '**********************************
        Next
    End Sub
    Private Sub calidadfat()
        Dim extension As String
        Dim nombrearchivo As String = ""
        Dim linea As Integer
        'Dim folder As New DirectoryInfo("d:\documentos\secretaria\analisis\leche\bentley-delta\pasados\calidad de leche")
        Dim folder As New DirectoryInfo("Y:\documentos\secretaria\analisis\leche\bentley-delta\Calidad de leche")
        'Dim folder As New DirectoryInfo("\\192.168.1.10\E\documentos\secretaria\resultados informes 2012")

        ' For Each file As FileInfo In folder.GetFiles("*.xls, *.CSV, *.fat")
        For Each file As FileInfo In folder.GetFiles("*.fat")
            'ListBox1.Items.Add(file.Name)
            nombrearchivo = file.Name
            linea = 1
            extension = Microsoft.VisualBasic.Right(file.Name, 3)
            'Dim objReader As New StreamReader("d:\documentos\secretaria\analisis\leche\bentley-delta\pasados\calidad de leche\" & file.Name)
            Dim objReader As New StreamReader("Y:\documentos\secretaria\analisis\leche\bentley-delta\Calidad de leche\" & file.Name)
            Dim sLine As String = ""
            'Dim arrText As New ArrayList()
            ''Dim arraytext() As String

            Dim matricula As String = ""
            Dim grasa As Double = 0
            Dim proteina As Double = 0
            Dim lactosa As Double = 0
            Dim st As Double = 0
            Dim rc As Integer = 0
            Dim ficha As String = ""
            Dim ficha2 As String = ""
            Dim ficha3 As String = ""
            Dim equipo As String = ""
            Dim producto As String = ""
            Dim crioscopia As Integer = 0
            Dim urea As Integer = 0
            Dim proteinav As Double = 0
            Dim caseina As Double = 0
            Dim densidad As Double = 0
            Dim ph As Double = 0

            ' *** SI EL ARCHIVO ES FAT **************************************************************************************
            If extension = "fat" Or extension = "FAT" Then
                Dim c As New dImpCalidad()
                Dim cuentalinea As Long = 1
                Do
                    sLine = objReader.ReadLine()
                    If Not sLine Is Nothing Then
                        Dim Texto As String
                        Dim id As Integer = 0

                        ficha2 = Mid(file.Name, Len(file.Name) - 4, 1)
                        ficha3 = Mid(file.Name, 1, 1)
                        If ficha2 = "a" Or ficha2 = "A" Or ficha2 = "b" Or ficha2 = "B" Or ficha2 = "c" Or ficha2 = "C" Or ficha2 = "d" Or ficha2 = "D" Then
                            ficha = Mid(file.Name, 1, Len(file.Name) - 5)
                        Else
                            ficha = Mid(file.Name, 1, Len(file.Name) - 4)
                        End If
                        If Mid(ficha, 1, 1) = "l" Or Mid(ficha, 1, 1) = "L" Then
                            'Dim MyString As String = ficha
                            'ficha3 = MyString.Remove(1, 1)
                            Dim MyString As String = ficha
                            Dim MyChar As Char() = {"l"c, "L"c}
                            Dim NewString As String = MyString.TrimStart(MyChar)
                            ficha3 = NewString
                        Else
                            ficha3 = ficha
                        End If
                        Dim fechaoriginal As Date = Now()
                        Dim fecha As String
                        fecha = Format(fechaoriginal, "yyyy-MM-dd")
                        Texto = sLine
                        id = Trim(Mid(Texto, 1, 8))
                        matricula = Trim(Mid(Texto, 9, 9))
                        If Trim(Mid(Texto, 18, 9)) <> "" Then
                            Try
                                grasa = Trim(Mid(Texto, 18, 9))
                            Catch ex As Exception
                                MsgBox("Error en archivo: " & file.Name & ", línea: " & cuentalinea & ", valor: Grasa")
                                Exit Sub
                            End Try

                        Else
                            grasa = -1
                        End If
                        If Trim(Mid(Texto, 27, 9)) <> "" Then
                            Try
                                proteina = Trim(Mid(Texto, 27, 9))
                            Catch ex As Exception
                                MsgBox("Error en archivo: " & file.Name & ", línea: " & cuentalinea & ", valor: Proteína")
                                Exit Sub
                            End Try

                        Else
                            proteina = -1
                        End If
                        If Trim(Mid(Texto, 36, 9)) <> "" Then
                            Try
                                lactosa = Trim(Mid(Texto, 36, 9))
                            Catch ex As Exception
                                MsgBox("Error en archivo: " & file.Name & ", línea: " & cuentalinea & ", valor: Lactosa")
                                Exit Sub
                            End Try

                        Else
                            lactosa = -1
                        End If
                        If Trim(Mid(Texto, 45, 9)) <> "" Then
                            Try
                                st = Trim(Mid(Texto, 45, 9))
                            Catch ex As Exception
                                MsgBox("Error en archivo: " & file.Name & ", línea: " & cuentalinea & ", valor: Sólidos totales")
                                Exit Sub
                            End Try

                        Else
                            st = -1
                        End If
                        If Trim(Mid(Texto, 54, 10)) <> "" Then
                            Try
                                rc = Trim(Mid(Texto, 54, 10))
                            Catch ex As Exception
                                MsgBox("Error en archivo: " & file.Name & ", línea: " & cuentalinea & ", valor: RC")
                                Exit Sub
                            End Try

                        Else
                            rc = -1
                        End If

                        c.FICHA = ficha3
                        c.FECHA = fecha
                        c.EQUIPO = "bentley"
                        c.PRODUCTO = "leche"
                        c.MUESTRA = matricula
                        c.RC = rc
                        c.GRASA = grasa
                        c.PROTEINA = proteina
                        c.LACTOSA = lactosa
                        c.ST = st
                        c.CRIOSCOPIA = -1
                        c.UREA = -1
                        c.PROTEINAV = -1
                        c.CASEINA = -1
                        c.DENSIDAD = -1
                        c.PH = -1
                        c.guardar()
                        cuentalinea = cuentalinea + 1
                    End If
                Loop Until sLine Is Nothing
                objReader.Close()
            End If


            '*** MOVER ARCHIVO ***********************************************************************
            'Dim sArchivoOrigen As String = "d:\documentos\secretaria\analisis\leche\bentley-delta\pasados\calidad de leche\" & nombrearchivo
            Dim sArchivoOrigen As String = "Y:\documentos\secretaria\analisis\leche\bentley-delta\Calidad de leche\" & nombrearchivo
            'Dim sRutaDestino As String = "d:\documentos\secretaria\analisis\leche\bentley-delta\pasados\calidad de leche\pasados NET\" & nombrearchivo
            Dim sRutaDestino As String = "Y:\documentos\secretaria\analisis\leche\bentley-delta\pasados\calidad de leche\pasados NET\" & nombrearchivo

            Try
                ' Mover el fichero.si existe lo sobreescribe  
                My.Computer.FileSystem.MoveFile(sArchivoOrigen, _
                                                sRutaDestino, _
                                                True)
                'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                ' errores  
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try

            '***********************************
            'Insert tabla preinforme_calidad
            Dim pi As New dPreinformes
            Dim fechaactual As Date = Now()
            Dim _fecha As String
            _fecha = Format(fechaactual, "yyyy-MM-dd")
            pi.FICHA = ficha3
            pi = pi.buscar
            If Not pi Is Nothing Then
            Else
                Dim pi2 As New dPreinformes
                pi2.FICHA = ficha3
                pi2.TIPO = 10
                pi2.CREADO = 0
                pi2.FECHA = _fecha
                pi2.guardar()
                pi2 = Nothing
            End If
            pi = Nothing

            ' Grabar estado de la ficha
            Dim est As New dEstados
            est.FICHA = ficha3
            est.ESTADO = 4
            est.FECHA = _fecha
            'est.guardar2()
            est = Nothing
            '****************************

            'Dim pical As New dPreinformeCalidad
            'Dim fechaactual As Date = Now()
            'Dim _fecha As String
            '_fecha = Format(fechaactual, "yyyy-MM-dd")
            'pical.FICHA = ficha3
            'pical = pical.buscar
            'If Not pical Is Nothing Then
            'Else
            '    Dim pical2 As New dPreinformeCalidad
            '    pical2.FICHA = ficha3
            '    pical2.CREADO = 0
            '    pical2.FECHA = _fecha
            '    pical2.guardar()
            '    pical2 = Nothing
            'End If
            'pical = Nothing
            '**********************************
        Next
    End Sub
    Private Sub ibc()
        Dim extension As String
        Dim nombrearchivo As String = ""
        Dim linea As Integer
        Dim ficha As String = ""
        Dim ficha2 As String = ""
        Dim ficha3 As String = "0"
        Dim fecha2 As String = ""
        '**********************************************************************************
        Dim El_Ping As Boolean
        Dim eco As New System.Net.NetworkInformation.Ping
        Dim res As System.Net.NetworkInformation.PingReply
        Dim ip As Net.IPAddress

        ip = Net.IPAddress.Parse("192.168.1.50")
        res = eco.Send(ip)

        If res.Status = System.Net.NetworkInformation.IPStatus.Success Then

            El_Ping = (My.Computer.Network.Ping("ibc1123"))


        End If


        'If (My.Computer.Network.Ping("ibc1123")) = True Then
        'El_Ping = (My.Computer.Network.Ping("ibc1123"))
        'End If
        'Acá mandamos los mensajes para las 2 posibilidades
        If El_Ping = False Then
            'si no se pudo acceder ,avisamos
            'MsgBox("El servidor no está disponible.", MsgBoxStyle.Critical, "Error")
        Else
            'MsgBox("Servidor disponible.", MsgBoxStyle.Information, "Aviso")
            Dim folder As New DirectoryInfo("\\Ibc1123\Carol")
            For Each file As FileInfo In folder.GetFiles("*.csv")
                'ListBox1.Items.Add(file.Name)
                nombrearchivo = file.Name
                linea = 1
                extension = Microsoft.VisualBasic.Right(file.Name, 3)
                Dim objReader2 As New StreamReader("\\Ibc1123\Carol\" & file.Name)
                Dim sLine As String = ""
                'Dim arrText As New ArrayList()
                Dim arraytext() As String

                'Dim ficha As String = ""
                'Dim ficha2 As String = ""
                'Dim ficha3 As String
                Dim muestra As String = ""
                Dim idibc As Integer = 0
                Dim ibc As Long = 0
                Dim rb As Integer = 0

                ' *** SI EL ARCHIVO ES CSV **************************************************************************************
                If extension = "csv" Or extension = "CSV" Then
                    Dim c As New dImpIbc()
                    Do
                        sLine = objReader2.ReadLine()

                        If Not sLine Is Nothing Then
                            'arrText.Add(sLine)
                            arraytext = Split(sLine, ",")
                            Dim muestra2 As String
                            Dim muestrax As String

                            If Trim(arraytext(1)) <> "" Then
                                muestra = arraytext(1)
                                muestrax = Replace(muestra, Chr(34), "")
                                If muestrax <> "" Then
                                    muestra2 = muestrax
                                Else
                                    muestra = arraytext(7)
                                    muestrax = Replace(muestra, Chr(34), "")
                                    If muestrax <> "" Then
                                        muestra2 = muestrax
                                    Else
                                        muestra2 = "error"
                                    End If
                                End If
                            Else
                                If arraytext.Length > 7 Then
                                    muestra = arraytext(7)
                                    muestrax = Replace(muestra, Chr(34), "")
                                    If muestrax <> "" Then
                                        muestra2 = muestrax
                                    Else
                                        muestra2 = "error"
                                    End If
                                Else
                                    muestra2 = "error"
                                End If

                            End If

                            'muestra2 = Replace(muestra, Chr(34), "")

                            If Trim(arraytext(2)) <> "" Then
                                idibc = arraytext(2)
                            Else
                                idibc = -1
                            End If
                            If Trim(arraytext(4)) <> "" Then
                                ibc = arraytext(4)
                            Else
                                ibc = -1
                            End If
                            If Trim(arraytext(5)) <> "" Then
                                rb = arraytext(5)
                            Else
                                rb = -1
                            End If

                            ficha2 = Mid(file.Name, Len(file.Name) - 4, 1)
                            ficha3 = Mid(file.Name, 1, 1)
                            If ficha2 = "a" Or ficha2 = "A" Or ficha2 = "b" Or ficha2 = "B" Or ficha2 = "c" Or ficha2 = "C" Or ficha2 = "d" Or ficha2 = "D" Then
                                ficha = Mid(file.Name, 1, Len(file.Name) - 5)
                            Else
                                ficha = Mid(file.Name, 1, Len(file.Name) - 4)
                            End If
                            If Mid(ficha, 1, 1) = "l" Or Mid(ficha, 1, 1) = "L" Then
                                'Dim MyString As String = ficha
                                'ficha3 = MyString.Remove(1, 1)
                                Dim MyString As String = ficha
                                Dim MyChar As Char() = {"l"c, "L"c}
                                Dim NewString As String = MyString.TrimStart(MyChar)
                                ficha3 = NewString
                            Else
                                ficha3 = ficha
                            End If
                            Dim fechaoriginal As Date = Now()
                            Dim fecha As String
                            fecha = Format(fechaoriginal, "yyyy-MM-dd")
                            fecha2 = Format(fechaoriginal, "yyyy-MM-dd")

                            c.FICHA = ficha3
                            c.MUESTRA = muestra2
                            c.IDIBC = idibc
                            c.IBC = ibc
                            c.RB = rb
                            c.FECHA = fecha
                            c.guardar()
                        End If
                        linea = linea + 1
                    Loop Until sLine Is Nothing
                    objReader2.Close()

                    ' Grabar estado de la ficha
                    Dim est As New dEstados
                    est.FICHA = ficha3
                    est.ESTADO = 3
                    est.FECHA = fecha2
                    'est.guardar2()
                    est = Nothing
                    '****************************

                End If



                '*** MOVER ARCHIVO ***********************************************************************
                Dim sArchivoOrigen As String = "\\Ibc1123\Carol\" & nombrearchivo
                'Dim sRutaDestino1 As String = "d:\documentos\secretaria\analisis\leche\ibc\" & nombrearchivo
                Dim sRutaDestino1 As String = "Y:\documentos\secretaria\analisis\leche\ibc\" & nombrearchivo
                Dim sRutaDestino As String = "\\Ibc1123\Carol\pasados\" & nombrearchivo

                Try
                    ' Mover el fichero.si existe lo sobreescribe  
                    My.Computer.FileSystem.CopyFile(sArchivoOrigen, _
                                                    sRutaDestino1, _
                                                    True)

                    My.Computer.FileSystem.MoveFile(sArchivoOrigen, _
                                                    sRutaDestino, _
                                                    True)
                    'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                    ' errores  
                Catch ex As Exception
                    MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
                End Try
            Next

            '***********************************
            'Insert tabla preinforme_calidad
            Dim pi As New dPreinformes
            Dim fechaactual As Date = Now()
            Dim _fecha As String
            _fecha = Format(fechaactual, "yyyy-MM-dd")
            pi.FICHA = ficha3
            pi = pi.buscar
            If Not pi Is Nothing Then
            Else
                Dim pi2 As New dPreinformes
                pi2.FICHA = ficha3
                pi2.TIPO = 10
                pi2.CREADO = 0
                pi2.FECHA = _fecha
                pi2.guardar()
                pi2 = Nothing
            End If
            pi = Nothing



        End If
        '***********************************************************************************



    End Sub
    Private Sub controllecherocsv()
        Dim extension As String
        Dim nombrearchivo As String = ""
        Dim linea As Integer
        'Dim folder As New DirectoryInfo("d:\documentos\secretaria\analisis\leche\bentley-delta\pasados\control lechero")
        Dim folder As New DirectoryInfo("Y:\documentos\secretaria\analisis\leche\bentley-delta\Control lechero")
        For Each file As FileInfo In folder.GetFiles("*.csv")
            'ListBox1.Items.Add(file.Name)
            nombrearchivo = file.Name
            If nombrearchivo.Length < 12 Then 'controlo si el archivo es de delta 400
                linea = 1
                extension = Microsoft.VisualBasic.Right(file.Name, 3)
                'Dim objReader As New StreamReader("d:\documentos\secretaria\analisis\leche\bentley-delta\pasados\control lechero\" & file.Name)
                Dim objReader As New StreamReader("Y:\documentos\secretaria\analisis\leche\bentley-delta\Control lechero\" & file.Name)
                Dim sLine As String = ""
                'Dim arrText As New ArrayList()
                Dim arraytext() As String

                Dim matricula As String = ""
                Dim grasa As Double = 0
                Dim proteina As Double = 0
                Dim lactosa As Double = 0
                Dim st As Double = 0
                Dim rc As Integer = 0
                Dim ficha As String = ""
                Dim ficha2 As String = ""
                Dim ficha3 As String = ""
                Dim equipo As String = ""
                Dim producto As String = ""
                Dim crioscopia As Integer = 0
                Dim urea As Integer = 0
                Dim proteinav As Double = 0
                Dim caseina As Double = 0
                Dim densidad As Double = 0
                Dim ph As Double = 0
                ' *** SI EL ARCHIVO ES CSV **************************************************************************************
                If extension = "csv" Or extension = "CSV" Then
                    Dim c As New dImpControl()
                    Dim ca As New dControlAux
                    Dim sa As New dSolicitudAnalisis
                    Dim p As New dCliente


                    Do


                        sLine = objReader.ReadLine()
                        If linea = 3 Then
                            arraytext = Split(sLine, ";")
                            If arraytext.Length < 11 Then
                                arraytext = Split(sLine, ",")
                            End If
                            producto = Trim(arraytext(10))
                        End If
                        If Not sLine Is Nothing Then
                            If Mid(sLine, 1, 2) <> ";;" Then ' controla fin de linea
                                If linea >= 8 Then
                                    'arrText.Add(sLine)
                                    arraytext = Split(sLine, ";")
                                    If arraytext.Length < 39 Then
                                        arraytext = Split(sLine, ",")
                                    End If

                                    If Trim(arraytext(1)) <> "" Then

                                        matricula = Trim(arraytext(5))

                                        If arraytext.Length <= 13 Then
                                            grasa = -1
                                            proteina = -1
                                            lactosa = -1
                                            st = -1
                                            If Trim(arraytext(11)) <> "" And Trim(arraytext(11)) <> "-" Then
                                                Try
                                                    rc = arraytext(11)
                                                Catch ex As Exception
                                                    MsgBox("Error en archivo: " & file.Name & ", línea: " & linea & ", valor: RC")
                                                    Exit Sub
                                                End Try

                                            Else
                                                rc = -1
                                            End If
                                            crioscopia = -1
                                            urea = -1
                                            proteinav = -1
                                            caseina = -1
                                            densidad = -1
                                            ph = -1
                                        Else
                                            Dim prueba As String
                                            prueba = Trim(arraytext(13))
                                            If prueba <> "-" Then
                                                'arraytext(8) = arraytext(13).Replace(" "c, String.Empty)

                                                If Trim(arraytext(13)) <> "" Then
                                                    Try
                                                        grasa = arraytext(13)
                                                    Catch ex As Exception
                                                        MsgBox("Error en archivo: " & file.Name & ", línea: " & linea & ", valor: Grasa")
                                                        Exit Sub
                                                    End Try

                                                Else
                                                    grasa = -1
                                                End If
                                                If Trim(arraytext(14)) <> "" Then
                                                    Try
                                                        proteina = arraytext(14)
                                                    Catch ex As Exception
                                                        MsgBox("Error en archivo: " & file.Name & ", línea: " & linea & ", valor: Proteína")
                                                        Exit Sub
                                                    End Try

                                                Else
                                                    proteina = -1
                                                End If
                                                If Trim(arraytext(15)) <> "" Then
                                                    Try
                                                        lactosa = arraytext(15)
                                                    Catch ex As Exception
                                                        MsgBox("Error en archivo: " & file.Name & ", línea: " & linea & ", valor: Lactosa")
                                                        Exit Sub
                                                    End Try

                                                Else
                                                    lactosa = -1
                                                End If
                                                If Trim(arraytext(16)) <> "" Then
                                                    Try
                                                        st = arraytext(16)
                                                    Catch ex As Exception
                                                        MsgBox("Error en archivo: " & file.Name & ", línea: " & linea & ", valor: Sólidos totales")
                                                        Exit Sub
                                                    End Try

                                                Else
                                                    st = -1
                                                End If
                                                If Trim(arraytext(11)) <> "" And Trim(arraytext(11)) <> "-" Then
                                                    Try
                                                        rc = arraytext(11)
                                                    Catch ex As Exception
                                                        MsgBox("Error en archivo: " & file.Name & ", línea: " & linea & ", valor: RC")
                                                        Exit Sub
                                                    End Try

                                                Else
                                                    rc = -1
                                                End If

                                                If Trim(arraytext(17)) <> "" Then
                                                    Try
                                                        crioscopia = arraytext(17)
                                                    Catch ex As Exception
                                                        MsgBox("Error en archivo: " & file.Name & ", línea: " & linea & ", valor: Crioscopía")
                                                        Exit Sub
                                                    End Try

                                                Else
                                                    crioscopia = -1
                                                End If

                                                If Trim(arraytext(18)) <> "" Then
                                                    Dim verifica As String = Trim(arraytext(18))
                                                    If Mid(verifica, 1, 1) = "-" Then
                                                        urea = -1
                                                    Else
                                                        Try
                                                            urea = arraytext(18)
                                                        Catch ex As Exception
                                                            MsgBox("Error en archivo: " & file.Name & ", línea: " & linea & ", valor: Urea")
                                                            Exit Sub
                                                        End Try

                                                    End If

                                                Else
                                                    urea = -1
                                                End If
                                                If Trim(arraytext(28)) <> "" Then
                                                    Try
                                                        proteinav = arraytext(28)
                                                    Catch ex As Exception
                                                        MsgBox("Error en archivo: " & file.Name & ", línea: " & linea & ", valor: Proteína verdadera")
                                                        Exit Sub
                                                    End Try

                                                Else
                                                    proteinav = -1
                                                End If
                                                If Trim(arraytext(29)) <> "" Then
                                                    Try
                                                        caseina = arraytext(29)
                                                    Catch ex As Exception
                                                        MsgBox("Error en archivo: " & file.Name & ", línea: " & linea & ", valor: Caseína")
                                                        Exit Sub
                                                    End Try

                                                Else
                                                    caseina = -1
                                                End If
                                                If Trim(arraytext(30)) <> "" Then
                                                    Try
                                                        densidad = arraytext(30)
                                                    Catch ex As Exception
                                                        MsgBox("Error en archivo: " & file.Name & ", línea: " & linea & ", valor: Densidad")
                                                        Exit Sub
                                                    End Try

                                                Else
                                                    densidad = -1
                                                End If
                                                If Trim(arraytext(36)) <> "" Then
                                                    Try
                                                        ph = arraytext(36)
                                                    Catch ex As Exception
                                                        MsgBox("Error en archivo: " & file.Name & ", línea: " & linea & ", valor: pH")
                                                        Exit Sub
                                                    End Try

                                                Else
                                                    ph = -1
                                                End If
                                            Else
                                                grasa = -1
                                                proteina = -1
                                                lactosa = -1
                                                st = -1
                                                rc = -1
                                                crioscopia = -1
                                                urea = -1
                                                proteinav = -1
                                                caseina = -1
                                                densidad = -1
                                                ph = -1
                                            End If
                                        End If


                                        ficha2 = Mid(file.Name, Len(file.Name) - 4, 1)
                                        ficha3 = Mid(file.Name, 1, 1)
                                        If ficha2 = "a" Or ficha2 = "A" Or ficha2 = "b" Or ficha2 = "B" Or ficha2 = "c" Or ficha2 = "C" Or ficha2 = "d" Or ficha2 = "D" Or ficha2 = "e" Or ficha2 = "E" Or ficha2 = "f" Or ficha2 = "F" Or ficha2 = "g" Or ficha2 = "G" Or ficha2 = "h" Or ficha2 = "H" Or ficha2 = "i" Or ficha2 = "I" Or ficha2 = "j" Or ficha2 = "J" Then
                                            ficha = Mid(file.Name, 1, Len(file.Name) - 5)
                                        Else
                                            ficha = Mid(file.Name, 1, Len(file.Name) - 4)
                                        End If
                                        If Mid(ficha, 1, 1) = "l" Or Mid(ficha, 1, 1) = "L" Then
                                            'Dim MyString As String = ficha
                                            'ficha3 = MyString.Remove(1, 1)
                                            Dim MyString As String = ficha
                                            Dim MyChar As Char() = {"l"c, "L"c}
                                            Dim NewString As String = MyString.TrimStart(MyChar)
                                            ficha3 = NewString
                                        Else
                                            ficha3 = ficha
                                        End If

                                        Dim fechaoriginal As Date = Now()
                                        Dim fecha As String
                                        fecha = Format(fechaoriginal, "yyyy-MM-dd")

                                        c.FICHA = ficha3
                                        c.FECHA = fecha
                                        c.EQUIPO = "delta"
                                        c.PRODUCTO = producto
                                        c.MUESTRA = matricula
                                        c.RC = rc
                                        c.GRASA = grasa
                                        c.PROTEINA = proteina
                                        c.LACTOSA = lactosa
                                        c.ST = st
                                        c.CRIOSCOPIA = crioscopia
                                        c.UREA = urea
                                        c.PROTEINAV = proteinav
                                        c.CASEINA = caseina
                                        c.DENSIDAD = densidad
                                        c.PH = ph
                                        c.guardar()

                                        ca.FICHA = ficha3
                                        ca.FECHA = fecha
                                        sa.ID = ficha3
                                        sa = sa.buscar
                                        ca.PRODUCTOR = sa.IDPRODUCTOR
                                        ca.MUESTRA = matricula
                                        ca.RC = rc
                                        ca.TAMBO = sa.TAMBO
                                        ca.guardar()


                                    End If
                                End If
                            End If 'controla fin de linea
                        End If
                        linea = linea + 1
                    Loop Until sLine Is Nothing

                    objReader.Close()
                End If


                '*** MOVER ARCHIVO ***********************************************************************
                'Dim sArchivoOrigen As String = "d:\documentos\secretaria\analisis\leche\bentley-delta\pasados\control lechero\" & nombrearchivo
                Dim sArchivoOrigen As String = "Y:\documentos\secretaria\analisis\leche\bentley-delta\Control lechero\" & nombrearchivo
                'Dim sRutaDestino As String = "d:\documentos\secretaria\analisis\leche\bentley-delta\pasados\control lechero\pasados NET\" & nombrearchivo
                Dim sRutaDestino As String = "Y:\documentos\secretaria\analisis\leche\bentley-delta\pasados\control lechero\pasados NET\" & nombrearchivo

                Try
                    ' Mover el fichero.si existe lo sobreescribe  
                    My.Computer.FileSystem.MoveFile(sArchivoOrigen, _
                                                    sRutaDestino, _
                                                    True)
                    'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                    ' errores  
                Catch ex As Exception
                    MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
                End Try

                '***********************************
                'Insert tabla preinforme_control
                Dim pi As New dPreinformes
                Dim fechaactual As Date = Now()
                Dim _fecha As String
                _fecha = Format(fechaactual, "yyyy-MM-dd")
                pi.FICHA = ficha3
                pi = pi.buscar
                If Not pi Is Nothing Then
                Else
                    Dim pi2 As New dPreinformes
                    pi2.FICHA = ficha3
                    pi2.TIPO = 1
                    pi2.CREADO = 0
                    pi2.FECHA = _fecha
                    pi2.guardar()
                    pi2 = Nothing
                End If
                pi = Nothing

                ' Grabar estado de la ficha
                Dim est As New dEstados
                est.FICHA = ficha3
                est.ESTADO = 4
                est.FECHA = _fecha
                'est.guardar2()
                est = Nothing
                '****************************

                'Dim picon As New dPreinformeControl
                'Dim fechaactual As Date = Now()
                'Dim _fecha As String
                '_fecha = Format(fechaactual, "yyyy-MM-dd")
                'picon.FICHA = ficha3
                'picon = picon.buscar
                'If Not picon Is Nothing Then
                'Else
                '    Dim picon2 As New dPreinformeControl
                '    picon2.FICHA = ficha3
                '    picon2.CREADO = 0
                '    picon2.FECHA = _fecha
                '    picon2.guardar()
                '    picon2 = Nothing
                'End If
                'picon = Nothing

                '**********************************
            End If 'fin de control si archivoes de delta 400
        Next
    End Sub
    Private Sub controllecheroxls()
        Dim extension As String
        Dim nombrearchivo As String = ""
        Dim linea As Integer
        'Dim folder As New DirectoryInfo("d:\documentos\secretaria\analisis\leche\bentley-delta\pasados\control lechero")
        Dim folder As New DirectoryInfo("Y:\documentos\secretaria\analisis\leche\bentley-delta\Control lechero")
        For Each file As FileInfo In folder.GetFiles("*.xls")
            'ListBox1.Items.Add(file.Name)
            nombrearchivo = file.Name
            linea = 1
            extension = Microsoft.VisualBasic.Right(file.Name, 3)
            'Dim objReader As New StreamReader("d:\documentos\secretaria\analisis\leche\bentley-delta\pasados\control lechero\" & file.Name)
            Dim objReader As New StreamReader("Y:\documentos\secretaria\analisis\leche\bentley-delta\Control lechero\" & file.Name)
            Dim sLine As String = ""
            'Dim arrText As New ArrayList()
            ''Dim arraytext() As String

            Dim matricula As String = ""
            Dim grasa As Double = 0
            Dim proteina As Double = 0
            Dim lactosa As Double = 0
            Dim st As Double = 0
            Dim rc As Integer = 0
            Dim ficha As String = ""
            Dim ficha2 As String = ""
            Dim ficha3 As String = ""
            Dim equipo As String = ""
            Dim producto As String = ""
            Dim crioscopia As Integer = 0
            Dim urea As Integer = 0
            Dim proteinav As Double = 0
            Dim caseina As Double = 0
            Dim densidad As Double = 0
            Dim ph As Double = 0

            ' *** SI EL ARCHIVO ES XLS **************************************************************************************
            If extension = "xls" Or extension = "XLS" Then
                Dim c As New dImpControl()
                Dim ca As New dControlAux
                Dim sa As New dSolicitudAnalisis
                Dim p As New dCliente

                Dim Arch As String, CantFilas As Integer
                'Arch = "d:\documentos\secretaria\analisis\leche\bentley-delta\pasados\control lechero\" & file.Name
                Arch = "Y:\documentos\secretaria\analisis\leche\bentley-delta\Control lechero\" & file.Name
                Dim x1app As Microsoft.Office.Interop.Excel.Application
                Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
                Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet

                x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
                x1libro = CType(x1app.Workbooks.Open(Arch), Microsoft.Office.Interop.Excel.Workbook)
                x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)
                Dim bandera As Integer = 0

                CantFilas = x1app.Range("a1").CurrentRegion.Rows.Count

                ficha2 = Mid(file.Name, Len(file.Name) - 4, 1)
                ficha3 = Mid(file.Name, 1, 1)
                If ficha2 = "a" Or ficha2 = "A" Or ficha2 = "b" Or ficha2 = "B" Or ficha2 = "c" Or ficha2 = "C" Or ficha2 = "d" Or ficha2 = "D" Or ficha2 = "e" Or ficha2 = "E" Or ficha2 = "f" Or ficha2 = "F" Or ficha2 = "g" Or ficha2 = "G" Or ficha2 = "h" Or ficha2 = "H" Or ficha2 = "i" Or ficha2 = "I" Or ficha2 = "j" Or ficha2 = "J" Then
                    ficha = Mid(file.Name, 1, Len(file.Name) - 5)
                Else
                    ficha = Mid(file.Name, 1, Len(file.Name) - 4)
                End If
                If Mid(ficha, 1, 1) = "l" Or Mid(ficha, 1, 1) = "L" Then
                    'Dim MyString As String = ficha
                    'ficha3 = MyString.Remove(1, 1)
                    Dim MyString As String = ficha
                    Dim MyChar As Char() = {"l"c, "L"c}
                    Dim NewString As String = MyString.TrimStart(MyChar)
                    ficha3 = NewString
                Else
                    ficha3 = ficha
                End If
                Dim fechaoriginal As Date = Now()
                Dim fecha As String
                fecha = Format(fechaoriginal, "yyyy-MM-dd")
                Dim id As String = ""
                For i = 1 To CantFilas
                    'If linea > 7 Then
                    If Trim(x1hoja.Cells(i, 1).formula) <> "" Then
                        id = Trim(x1hoja.Cells(i, 1).value)
                    Else
                        id = -1
                    End If
                    If Trim(x1hoja.Cells(i, 2).formula) <> "" Then
                        matricula = Trim(x1hoja.Cells(i, 2).value)
                    Else
                        matricula = -1
                    End If
                    If Trim(x1hoja.Cells(i, 3).formula) <> "" Then
                        Try
                            grasa = x1hoja.Cells(i, 3).value
                        Catch ex As Exception
                            MsgBox("Error en archivo: " & file.Name & ", línea: " & i & ", valor: Grasa")
                            Exit Sub
                        End Try

                    Else
                        grasa = -1
                    End If
                    If Trim(x1hoja.Cells(i, 4).formula) <> "" Then
                        Try
                            proteina = x1hoja.Cells(i, 4).value
                            bandera = 1
                        Catch ex As Exception
                            MsgBox("Error en archivo: " & file.Name & ", línea: " & i & ", valor: Proteína")
                            Exit Sub
                        End Try

                    Else
                        proteina = -1
                    End If
                    If Trim(x1hoja.Cells(i, 5).formula) <> "" Then
                        Try
                            lactosa = x1hoja.Cells(i, 5).value
                        Catch ex As Exception
                            MsgBox("Error en archivo: " & file.Name & ", línea: " & i & ", valor: Lactosa")
                            Exit Sub
                        End Try

                    Else
                        lactosa = -1
                    End If
                    If Trim(x1hoja.Cells(i, 6).formula) <> "" Then
                        Try
                            st = x1hoja.Cells(i, 6).value
                        Catch ex As Exception
                            MsgBox("Error en archivo: " & file.Name & ", línea: " & i & ", valor: Sólidos totales")
                            Exit Sub
                        End Try

                    Else
                        st = -1
                    End If
                    If Trim(x1hoja.Cells(i, 7).formula) <> "" Then
                        Try
                            rc = x1hoja.Cells(i, 7).value
                        Catch ex As Exception
                            MsgBox("Error en archivo: " & file.Name & ", línea: " & i & ", valor: RC")
                            Exit Sub
                        End Try

                    Else
                        rc = -1
                        bandera = 2
                    End If

                    If bandera = 0 Then
                        c.FICHA = ficha3
                        c.FECHA = fecha
                        c.EQUIPO = "bentley"
                        c.PRODUCTO = "leche"
                        c.MUESTRA = matricula
                        c.RC = grasa
                        c.GRASA = -1
                        c.PROTEINA = proteina
                        c.LACTOSA = lactosa
                        c.ST = st
                        c.CRIOSCOPIA = -1
                        c.UREA = -1
                        c.PROTEINAV = -1
                        c.CASEINA = -1
                        c.DENSIDAD = -1
                        c.PH = -1
                        c.guardar()

                        ca.FICHA = ficha3
                        ca.FECHA = fecha
                        sa.ID = ficha3
                        sa = sa.buscar
                        ca.PRODUCTOR = sa.IDPRODUCTOR
                        ca.MUESTRA = matricula
                        ca.RC = grasa
                        ca.TAMBO = sa.TAMBO
                        ca.guardar()
                    ElseIf bandera = 1 Then
                        c.FICHA = ficha3
                        c.FECHA = fecha
                        c.EQUIPO = "bentley"
                        c.PRODUCTO = "leche"
                        c.MUESTRA = matricula
                        c.RC = rc
                        c.GRASA = grasa
                        c.PROTEINA = proteina
                        c.LACTOSA = lactosa
                        c.ST = st
                        c.CRIOSCOPIA = -1
                        c.UREA = -1
                        c.PROTEINAV = -1
                        c.CASEINA = -1
                        c.DENSIDAD = -1
                        c.PH = -1
                        c.guardar()

                        ca.FICHA = ficha3
                        ca.FECHA = fecha
                        sa.ID = ficha3
                        sa = sa.buscar
                        ca.PRODUCTOR = sa.IDPRODUCTOR
                        ca.MUESTRA = matricula
                        ca.RC = rc
                        ca.TAMBO = sa.TAMBO
                        ca.guardar()
                    ElseIf bandera = 2 Then
                        c.FICHA = ficha3
                        c.FECHA = fecha
                        c.EQUIPO = "bentley"
                        c.PRODUCTO = "leche"
                        c.MUESTRA = id
                        c.RC = st
                        c.GRASA = matricula
                        c.PROTEINA = grasa
                        c.LACTOSA = proteina
                        c.ST = lactosa
                        c.CRIOSCOPIA = -1
                        c.UREA = -1
                        c.PROTEINAV = -1
                        c.CASEINA = -1
                        c.DENSIDAD = -1
                        c.PH = -1
                        c.guardar()

                        ca.FICHA = ficha3
                        ca.FECHA = fecha
                        sa.ID = ficha3
                        sa = sa.buscar
                        ca.PRODUCTOR = sa.IDPRODUCTOR
                        ca.MUESTRA = id
                        ca.RC = st
                        ca.TAMBO = sa.TAMBO
                        ca.guardar()
                    End If

                    'End If
                    'linea = linea + 1
                Next

                ' Cierro Excel
                x1libro.Close()
                x1app = Nothing
                x1libro = Nothing
                x1hoja = Nothing
                objReader.Close()

                Dim proceso As System.Diagnostics.Process()
                proceso = System.Diagnostics.Process.GetProcessesByName("EXCEL")

                For Each opro As System.Diagnostics.Process In proceso
                    'antes de iniciar el proceso obtengo la fecha en que inicie el 
                    'proceso para detener todos los procesos que excel que inicio
                    'mi código durante el proceso
                    opro.Kill()

                Next

            End If

            '*** MOVER ARCHIVO ***********************************************************************
            'Dim sArchivoOrigen As String = "d:\documentos\secretaria\analisis\leche\bentley-delta\pasados\control lechero\" & nombrearchivo
            Dim sArchivoOrigen As String = "Y:\documentos\secretaria\analisis\leche\bentley-delta\Control lechero\" & nombrearchivo
            'Dim sRutaDestino As String = "d:\documentos\secretaria\analisis\leche\bentley-delta\pasados\control lechero\pasados NET\" & nombrearchivo
            Dim sRutaDestino As String = "Y:\documentos\secretaria\analisis\leche\bentley-delta\pasados\control lechero\pasados NET\" & nombrearchivo

            Try
                ' Mover el fichero.si existe lo sobreescribe  
                My.Computer.FileSystem.MoveFile(sArchivoOrigen, _
                                                sRutaDestino, _
                                                True)
                'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                ' errores  
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try

            '***********************************
            'Insert tabla preinforme_control
            Dim pi As New dPreinformes
            Dim fechaactual As Date = Now()
            Dim _fecha As String
            _fecha = Format(fechaactual, "yyyy-MM-dd")
            pi.FICHA = ficha3
            pi = pi.buscar
            If Not pi Is Nothing Then
            Else
                Dim pi2 As New dPreinformes
                pi2.FICHA = ficha3
                pi2.TIPO = 1
                pi2.CREADO = 0
                pi2.FECHA = _fecha
                pi2.guardar()
                pi2 = Nothing
            End If
            pi = Nothing

            ' Grabar estado de la ficha
            Dim est As New dEstados
            est.FICHA = ficha3
            est.ESTADO = 4
            est.FECHA = _fecha
            'est.guardar2()
            est = Nothing
            '****************************

            'Dim picon As New dPreinformeControl
            'Dim fechaactual As Date = Now()
            'Dim _fecha As String
            '_fecha = Format(fechaactual, "yyyy-MM-dd")
            'picon.FICHA = ficha3
            'picon = picon.buscar
            'If Not picon Is Nothing Then
            'Else
            '    Dim picon2 As New dPreinformeControl
            '    picon2.FICHA = ficha3
            '    picon2.CREADO = 0
            '    picon2.FECHA = _fecha
            '    picon2.guardar()
            '    picon2 = Nothing
            'End If
            'picon = Nothing

            '**********************************
        Next
    End Sub
    Private Sub controllecherofat()
        Dim extension As String
        Dim nombrearchivo As String = ""
        Dim linea As Integer
        'Dim folder As New DirectoryInfo("d:\documentos\secretaria\analisis\leche\bentley-delta\pasados\control lechero")
        Dim folder As New DirectoryInfo("Y:\documentos\secretaria\analisis\leche\bentley-delta\Control lechero")
        For Each file As FileInfo In folder.GetFiles("*.fat")
            'ListBox1.Items.Add(file.Name)
            nombrearchivo = file.Name
            linea = 1
            extension = Microsoft.VisualBasic.Right(file.Name, 3)
            'Dim objReader As New StreamReader("d:\documentos\secretaria\analisis\leche\bentley-delta\pasados\control lechero\" & file.Name)
            Dim objReader As New StreamReader("Y:\documentos\secretaria\analisis\leche\bentley-delta\Control lechero\" & file.Name)
            Dim sLine As String = ""
            'Dim arrText As New ArrayList()
            '' Dim arraytext() As String

            Dim matricula As String = ""
            Dim grasa As Double = 0
            Dim proteina As Double = 0
            Dim lactosa As Double = 0
            Dim st As Double = 0
            Dim rc As Integer = 0
            Dim ficha As String = ""
            Dim ficha2 As String = ""
            Dim ficha3 As String = ""
            Dim equipo As String = ""
            Dim producto As String = ""
            Dim crioscopia As Integer = 0
            Dim urea As Integer = 0
            Dim proteinav As Double = 0
            Dim caseina As Double = 0
            Dim densidad As Double = 0
            Dim ph As Double = 0

            ' *** SI EL ARCHIVO ES FAT **************************************************************************************
            If extension = "fat" Or extension = "FAT" Then
                Dim c As New dImpControl()
                Dim ca As New dControlAux
                Dim sa As New dSolicitudAnalisis
                Dim p As New dCliente

                Dim cuentalinea As Long = 1
                Do
                    sLine = objReader.ReadLine()

                    Dim fechaoriginal As Date = Now()
                    Dim fecha As String = ""

                    If Not sLine Is Nothing Then
                        Dim Texto As String
                        Dim id As String = 0

                        ficha2 = Mid(file.Name, Len(file.Name) - 4, 1)
                        ficha3 = Mid(file.Name, 1, 1)
                        If ficha2 = "a" Or ficha2 = "A" Or ficha2 = "b" Or ficha2 = "B" Or ficha2 = "c" Or ficha2 = "C" Or ficha2 = "d" Or ficha2 = "D" Or ficha2 = "e" Or ficha2 = "E" Or ficha2 = "f" Or ficha2 = "F" Or ficha2 = "g" Or ficha2 = "G" Or ficha2 = "h" Or ficha2 = "H" Or ficha2 = "i" Or ficha2 = "I" Or ficha2 = "j" Or ficha2 = "J" Then
                            ficha = Mid(file.Name, 1, Len(file.Name) - 5)
                        Else
                            ficha = Mid(file.Name, 1, Len(file.Name) - 4)
                        End If
                        If Mid(ficha, 1, 1) = "l" Or Mid(ficha, 1, 1) = "L" Then
                            'Dim MyString As String = ficha
                            'ficha3 = MyString.Remove(1, 1)
                            Dim MyString As String = ficha
                            Dim MyChar As Char() = {"l"c, "L"c}
                            Dim NewString As String = MyString.TrimStart(MyChar)
                            ficha3 = NewString
                        Else
                            ficha3 = ficha
                        End If

                        fecha = Format(fechaoriginal, "yyyy-MM-dd")
                        Texto = sLine
                        id = Trim(Mid(Texto, 1, 8))
                        If Trim(Mid(Texto, 9, 9)) <> "" Then
                            matricula = Trim(Mid(Texto, 9, 9))
                        Else
                            matricula = id
                        End If

                        If Trim(Mid(Texto, 18, 9)) <> "" Then
                            Try
                                grasa = Trim(Mid(Texto, 18, 9))
                            Catch ex As Exception
                                MsgBox("Error en archivo: " & file.Name & ", línea: " & cuentalinea & ", valor: Grasa")
                                Exit Sub
                            End Try

                        Else
                            grasa = -1
                        End If
                        If Trim(Mid(Texto, 27, 9)) <> "" Then
                            Try
                                proteina = Trim(Mid(Texto, 27, 9))
                            Catch ex As Exception
                                MsgBox("Error en archivo: " & file.Name & ", línea: " & cuentalinea & ", valor: Proteína")
                                Exit Sub
                            End Try

                        Else
                            proteina = -1
                        End If
                        If Trim(Mid(Texto, 36, 9)) <> "" Then
                            Try
                                lactosa = Trim(Mid(Texto, 36, 9))
                            Catch ex As Exception
                                MsgBox("Error en archivo: " & file.Name & ", línea: " & cuentalinea & ", valor: Lactosa")
                                Exit Sub
                            End Try

                        Else
                            lactosa = -1
                        End If
                        If Trim(Mid(Texto, 45, 9)) <> "" Then
                            Try
                                st = Trim(Mid(Texto, 45, 9))
                            Catch ex As Exception
                                MsgBox("Error en archivo: " & file.Name & ", línea: " & cuentalinea & ", valor: Sólidos totales")
                                Exit Sub
                            End Try

                        Else
                            st = -1
                        End If
                        If Trim(Mid(Texto, 54, 10)) <> "" Then
                            Try
                                rc = Trim(Mid(Texto, 54, 10))
                            Catch ex As Exception
                                MsgBox("Error en archivo: " & file.Name & ", línea: " & cuentalinea & ", valor: RC")
                                Exit Sub
                            End Try

                        Else
                            rc = -1
                        End If
                    End If


                    If fecha <> "" Then
                        c.FICHA = ficha3
                        c.FECHA = fecha
                        c.EQUIPO = "bentley"
                        c.PRODUCTO = "leche"
                        c.MUESTRA = matricula
                        c.RC = rc
                        c.GRASA = grasa
                        c.PROTEINA = proteina
                        c.LACTOSA = lactosa
                        c.ST = st
                        c.CRIOSCOPIA = -1
                        c.UREA = -1
                        c.PROTEINAV = -1
                        c.CASEINA = -1
                        c.DENSIDAD = -1
                        c.PH = -1
                        c.guardar()

                        ca.FICHA = ficha3
                        ca.FECHA = fecha
                        sa.ID = ficha3
                        sa = sa.buscar
                        ca.PRODUCTOR = sa.IDPRODUCTOR
                        ca.MUESTRA = matricula
                        ca.RC = rc
                        ca.TAMBO = sa.TAMBO
                        ca.guardar()

                    End If

                    cuentalinea = cuentalinea + 1
                Loop Until sLine Is Nothing
                objReader.Close()
            End If


            '*** MOVER ARCHIVO ***********************************************************************
            'Dim sArchivoOrigen As String = "d:\documentos\secretaria\analisis\leche\bentley-delta\pasados\control lechero\" & nombrearchivo
            Dim sArchivoOrigen As String = "Y:\documentos\secretaria\analisis\leche\bentley-delta\Control lechero\" & nombrearchivo
            'Dim sRutaDestino As String = "d:\documentos\secretaria\analisis\leche\bentley-delta\pasados\control lechero\pasados NET\" & nombrearchivo
            Dim sRutaDestino As String = "Y:\documentos\secretaria\analisis\leche\bentley-delta\pasados\control lechero\pasados NET\" & nombrearchivo

            Try
                ' Mover el fichero.si existe lo sobreescribe  
                My.Computer.FileSystem.MoveFile(sArchivoOrigen, _
                                                sRutaDestino, _
                                                True)
                'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                ' errores  
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try

            '***********************************
            'Insert tabla preinforme_control
            Dim pi As New dPreinformes
            Dim fechaactual As Date = Now()
            Dim _fecha As String
            _fecha = Format(fechaactual, "yyyy-MM-dd")
            pi.FICHA = ficha3
            pi = pi.buscar
            If Not pi Is Nothing Then
            Else
                Dim pi2 As New dPreinformes
                pi2.FICHA = ficha3
                pi2.TIPO = 1
                pi2.CREADO = 0
                pi2.FECHA = _fecha
                pi2.guardar()
                pi2 = Nothing
            End If
            pi = Nothing

            ' Grabar estado de la ficha
            Dim est As New dEstados
            est.FICHA = ficha3
            est.ESTADO = 4
            est.FECHA = _fecha
            'est.guardar2()
            est = Nothing
            '****************************

            'Dim picon As New dPreinformeControl
            'Dim fechaactual As Date = Now()
            'Dim _fecha As String
            '_fecha = Format(fechaactual, "yyyy-MM-dd")
            'picon.FICHA = ficha3
            'picon = picon.buscar
            'If Not picon Is Nothing Then
            'Else
            '    Dim picon2 As New dPreinformeControl
            '    picon2.FICHA = ficha3
            '    picon2.CREADO = 0
            '    picon2.FECHA = _fecha
            '    picon2.guardar()
            '    picon2 = Nothing
            'End If
            'picon = Nothing

            '**********************************
        Next
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        importar()
    End Sub
    Private Sub importar()
        Me.Cursor = Cursors.WaitCursor
        Label2.Text = ""
        borrarimportacionescalidad()
        borrarimportacionescontrol()
        calidadcsv()
        'calidadcsv2()
        calidadxls()
        calidadfat()
        ibc()
        controllecherocsv()
        'controllecherocsv2()
        controllecheroxls()
        controllecherofat()
        'subircontrol()
        Me.Cursor = Cursors.Default
        Label2.Text = "Datos importados!"
        'Me.Close()
        Timer1.Enabled = True
    End Sub
    Private Sub borrarimportacionescalidad()
        Dim nombrearchivo As String = ""

        Dim folder As New DirectoryInfo("Y:\Documentos\SECRETARIA\Analisis\Leche\Bentley-delta\Calidad de leche")
        Dim _ficheros() As String
        _ficheros = Directory.GetFiles("Y:\Documentos\SECRETARIA\Analisis\Leche\Bentley-delta\Calidad de leche")
        If (_ficheros.Length > 0) Then
            For Each file As FileInfo In folder.GetFiles("*.csv")
                nombrearchivo = file.Name
                Dim ficha As String = ""
                Dim _calidad As New dCalidad
                ficha = Mid(file.Name, 1, Len(file.Name) - 4)
                _calidad.FICHA = ficha
                _calidad.eliminarxficha()
            Next
        End If
    End Sub
    Private Sub borrarimportacionescontrol()
        Dim nombrearchivo As String = ""

        Dim folder As New DirectoryInfo("Y:\Documentos\SECRETARIA\Analisis\Leche\Bentley-delta\Control lechero")
        Dim _ficheros() As String
        _ficheros = Directory.GetFiles("Y:\Documentos\SECRETARIA\Analisis\Leche\Bentley-delta\Control lechero")
        If (_ficheros.Length > 0) Then
            For Each file As FileInfo In folder.GetFiles("*.csv")
                nombrearchivo = file.Name
                Dim ficha As String = ""
                Dim _control As New dControl
                ficha = Mid(file.Name, 1, Len(file.Name) - 4)
                _control.FICHA = ficha
                _control.eliminarxficha()
            Next
        End If
    End Sub
    Private Sub subircontrol()
        Dim un As New dUltimoNumero
        Dim ultimonumero As Long
        un = un.buscar
        ultimonumero = un.CONTROLAUX
        Dim ca As New dControlAux
        Dim lista As New ArrayList
        Dim lista2 As New ArrayList
        Dim idficha As Long = 0
        Dim fecha As Date
        lista = ca.listarsinsubir(ultimonumero)
        If Not lista Is Nothing Then
            For Each ca In lista
                Dim ca2 As New dControlAux
                idficha = ca.FICHA
                lista2 = ca2.listarsinsubir2(idficha)
                If Not lista2 Is Nothing Then
                    If lista2.Count > 0 Then
                        For Each ca2 In lista2
                            Dim caweb As New dControlAuxWeb_com
                            caweb.FICHA = ca2.FICHA
                            fecha = ca2.FECHA
                            caweb.FECHA = Format(fecha, "yyyy-MM-dd")
                            caweb.PRODUCTOR = ca2.PRODUCTOR
                            caweb.MUESTRA = ca2.MUESTRA
                            caweb.RC = ca2.RC
                            caweb.guardar()
                            un.CONTROLAUX = caweb.FICHA
                            un.modificarcontrol()
                            caweb = Nothing
                        Next
                    End If
                End If
            Next
        End If

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.Close()
    End Sub
End Class