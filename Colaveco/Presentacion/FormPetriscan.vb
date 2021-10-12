Imports System
Imports System.IO
Imports System.Collections
Public Class FormPetriscan
    Private nombre_carpeta As String = ""
    Private index_petriscan As Integer = 0
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSeleccionar.Click
        Dim fichero As String
        Dim dlAbrir As New System.Windows.Forms.OpenFileDialog

        dlAbrir.Filter = "Archivos de Texto (*.txt)|*.txt|" & _
            "Archivos de log (*.log)|*.log|" & _
            "Todos los archivos (*.*)|*.*"
        dlAbrir.Multiselect = False
        dlAbrir.CheckFileExists = False
        dlAbrir.Title = "Selección de fichero"
        dlAbrir.ShowDialog()
        If dlAbrir.FileName <> "" Then
            fichero = dlAbrir.FileName
            txtFichero.Text = fichero
            nombre_carpeta = fichero
        End If
    End Sub

    Private Sub ButtonImportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonImportar.Click
        Dim un As New dUltimoNumero
        Dim carpeta_petri As String = ""
        Dim index_petri As Integer = 0
        un = un.buscar
        If Not un Is Nothing Then
            'carpeta_petri = un.CARPETAPETRI
            carpeta_petri = Replace(un.CARPETAPETRI, Chr(47), "\")
            index_petri = un.INDEXPETRI
        End If
        If nombre_carpeta = carpeta_petri Then

            Dim extension As String = ""
            Dim nombrearchivo As String = ""
            Dim linea As Integer
            'Dim folder As New DirectoryInfo("Y:\Documentos\SECRETARIA\Analisis\Leche\Bentley-delta\Calidad de leche")
            Dim folder As New DirectoryInfo("C:\")
            Dim _fichero As String = txtFichero.Text.Trim

            nombrearchivo = _fichero
            linea = 1
            extension = Mid(_fichero, 13)
            Dim objReader As New StreamReader(_fichero)
            Dim sLine As String = ""
            Dim arraytext() As String

            'Dim fecha As String = ""
            Dim fecha As Date
            Dim fec As String = ""
            Dim ficha As Long = 0
            Dim muestra As String = ""
            Dim dilucion As Integer = 0
            Dim dilucion2 As Integer = 0
            Dim rb As Integer = 0
            Dim rb2 As Integer = 0
            Dim celdaeliminada As String = ""
            Dim eliminado As Integer = 0
            Dim muestrant As String = ""
            Dim valor1 As Double = 0
            Dim valor2 As Double = 0
            Dim parcompleto As Integer = 0
            Dim parentesis1 As String = "("
            Dim parentesis2 As String = ")"
            Dim parent1 As Integer = 0
            Dim parent2 As Integer = 0
            Dim lectura As String = ""
            Dim muestraaux As String = ""
            Dim fichaaux As Long = 0
            Dim inicio As Integer = 0
            Dim fin As Integer = 0
            Dim antes As Integer = 0
            Dim petri As New dPetriscanAux
            Dim indice As Integer = 0


            ' *** SI EL ARCHIVO ES TXT **************************************************************************************

            If extension = "txt" Or extension = "TXT" Then
                Dim p As New dPetriscanAux
                Do
                    sLine = objReader.ReadLine()

                    If Not sLine Is Nothing Then
                        If sLine <> " " Then
                            If linea > 1 Then
                                'arrText.Add(sLine)
                                arraytext = Split(sLine, "|")

                                If arraytext.Length > 1 Then
                                    celdaeliminada = Mid(arraytext(0), 1, 7)
                                    If celdaeliminada = "DELETED" Then
                                        eliminado = 1
                                    Else
                                        eliminado = 0
                                        indice = Trim(arraytext(0))
                                    End If
                                End If

                                If indice > index_petri Then
                                    If eliminado = 0 Then
                                        lectura = Mid(arraytext(1), 1, 8)
                                        If lectura <> "Template" Then
                                            parent1 = InStr(4, arraytext(1), parentesis1, CompareMethod.Text)
                                            parent2 = InStr(4, arraytext(1), parentesis2, CompareMethod.Text)
                                            inicio = parent1 + 1
                                            fin = parent2 - inicio
                                            antes = parent1 - 1
                                            If parent1 > 0 Then
                                                fichaaux = Mid(arraytext(1), 1, antes)
                                                ficha = fichaaux
                                            End If
                                            If parent1 And parent2 > 0 Then
                                                muestraaux = Mid(arraytext(1), inicio, fin)
                                                muestra = muestraaux
                                            Else
                                                muestra = Trim(lectura)
                                            End If

                                            'fecha = Trim(arraytext(7))
                                            fecha = Trim(arraytext(7))
                                            dilucion = Trim(arraytext(2))
                                            If Trim(arraytext(3)) = "TNTC" Then
                                                rb = -1
                                            Else
                                                rb = Trim(arraytext(3))
                                            End If
                                            If dilucion = 2 Then
                                                dilucion2 = 100
                                            ElseIf dilucion = 3 Then
                                                dilucion2 = 1000
                                            ElseIf dilucion = 4 Then
                                                dilucion2 = 10000
                                            End If
                                            rb2 = rb * dilucion2


                                            fec = Format(fecha, "yyyy-MM-dd")
                                            petri.FECHA = fec
                                            petri.FICHA = ficha
                                            petri.MUESTRA = muestra
                                            petri.DILUCION = dilucion
                                            petri.RB = rb2
                                            petri.guardar()

                                            Dim un2 As New dUltimoNumero
                                            Dim nombre_carpeta2 As String = ""
                                            nombre_carpeta2 = Replace(nombre_carpeta, Chr(92), "/")
                                            un2.CARPETAPETRI = nombre_carpeta2
                                            un2.INDEXPETRI = indice
                                            un2.modificarpetri()
                                            un2 = Nothing
                                            nombre_carpeta2 = Nothing
                                        End If
                                    End If
                                End If

                            End If
                        End If
                    End If
                    linea = linea + 1
                Loop Until sLine Is Nothing
                objReader.Close()
            End If

        Else

            Dim extension As String = ""
            Dim nombrearchivo As String = ""
            Dim linea As Integer
            'Dim folder As New DirectoryInfo("Y:\Documentos\SECRETARIA\Analisis\Leche\Bentley-delta\Calidad de leche")
            Dim folder As New DirectoryInfo("C:\")
            Dim _fichero As String = txtFichero.Text.Trim

            nombrearchivo = _fichero
            linea = 1
            extension = Mid(_fichero, 13)
            Dim objReader As New StreamReader(_fichero)
            Dim sLine As String = ""
            Dim arraytext() As String

            'Dim fecha As String = ""
            Dim fecha As Date
            Dim fec As String = ""
            Dim ficha As Long = 0
            Dim muestra As String = ""
            Dim dilucion As Integer = 0
            Dim dilucion2 As Integer = 0
            Dim rb As Integer = 0
            Dim rb2 As Integer = 0
            Dim celdaeliminada As String = ""
            Dim eliminado As Integer = 0
            Dim muestrant As String = ""
            Dim valor1 As Double = 0
            Dim valor2 As Double = 0
            Dim parcompleto As Integer = 0
            Dim parentesis1 As String = "("
            Dim parentesis2 As String = ")"
            Dim parent1 As Integer = 0
            Dim parent2 As Integer = 0
            Dim lectura As String = ""
            Dim muestraaux As String = ""
            Dim fichaaux As Long = 0
            Dim inicio As Integer = 0
            Dim fin As Integer = 0
            Dim antes As Integer = 0
            Dim petri As New dPetriscanAux
            Dim indice As Integer = 0
            index_petri = 0

            ' *** SI EL ARCHIVO ES TXT **************************************************************************************

            If extension = "txt" Or extension = "TXT" Then
                Dim p As New dPetriscanAux
                Do
                    sLine = objReader.ReadLine()

                    If Not sLine Is Nothing Then
                        If sLine <> " " Then
                            If linea > 1 Then
                                'arrText.Add(sLine)
                                arraytext = Split(sLine, "|")

                                If arraytext.Length > 1 Then
                                    celdaeliminada = Mid(arraytext(0), 1, 7)
                                    If celdaeliminada = "DELETED" Then
                                        eliminado = 1
                                    Else
                                        eliminado = 0
                                        indice = Trim(arraytext(0))
                                    End If
                                End If


                                If indice > index_petri Then
                                    If eliminado = 0 Then
                                        lectura = Mid(arraytext(1), 1, 8)
                                        If lectura <> "Template" Then
                                            parent1 = InStr(4, arraytext(1), parentesis1, CompareMethod.Text)
                                            parent2 = InStr(4, arraytext(1), parentesis2, CompareMethod.Text)
                                            inicio = parent1 + 1
                                            fin = parent2 - inicio
                                            antes = parent1 - 1
                                            If parent1 > 0 Then
                                                fichaaux = Mid(arraytext(1), 1, antes)
                                                ficha = fichaaux
                                            End If
                                            If parent1 And parent2 > 0 Then
                                                muestraaux = Mid(arraytext(1), inicio, fin)
                                                muestra = muestraaux
                                            Else
                                                muestra = Trim(lectura)
                                            End If

                                            'fecha = Trim(arraytext(7))
                                            fecha = Trim(arraytext(7))
                                            dilucion = Trim(arraytext(2))
                                            If Trim(arraytext(3)) = "TNTC" Then
                                                rb = -1
                                            Else
                                                rb = Trim(arraytext(3))
                                            End If
                                            If dilucion = 2 Then
                                                dilucion2 = 100
                                            ElseIf dilucion = 3 Then
                                                dilucion2 = 1000
                                            ElseIf dilucion = 4 Then
                                                dilucion2 = 10000
                                            End If
                                            rb2 = rb * dilucion2


                                            fec = Format(fecha, "yyyy-MM-dd")
                                            petri.FECHA = fec
                                            petri.FICHA = ficha
                                            petri.MUESTRA = muestra
                                            petri.DILUCION = dilucion
                                            petri.RB = rb2
                                            petri.guardar()

                                            Dim un2 As New dUltimoNumero
                                            Dim nombre_carpeta2 As String = ""
                                            nombre_carpeta2 = Replace(nombre_carpeta, Chr(92), "/")
                                            un2.CARPETAPETRI = nombre_carpeta2
                                            un2.INDEXPETRI = indice
                                            un2.modificarpetri()
                                            un2 = Nothing
                                            nombre_carpeta2 = Nothing
                                        End If
                                    End If
                                End If

                            End If
                        End If
                    End If
                    linea = linea + 1
                Loop Until sLine Is Nothing
                objReader.Close()
            End If
        End If
        cargar_tabla_petriscan()
    End Sub
    Private Sub cargar_tabla_petriscan()
        Dim fecha As Date
        Dim fec As String = ""
        Dim paux As New dPetriscanAux
        Dim paux2 As New dPetriscanAux
        Dim paux3 As New dPetriscanAux
        Dim listadistintasfichas As New ArrayList
        Dim listadistintasmuestras As New ArrayList
        Dim lista As New ArrayList
        listadistintasfichas = paux.listardistintasfichas
        If Not listadistintasfichas Is Nothing Then
            If listadistintasfichas.Count > 0 Then
                For Each paux In listadistintasfichas
                    listadistintasmuestras = paux2.listardistintasmuestras(paux.FICHA)
                    If Not listadistintasmuestras Is Nothing Then
                        If listadistintasmuestras.Count > 0 Then
                            For Each paux2 In listadistintasmuestras
                                lista = paux3.listarxfichaxmuestra(paux2.FICHA, paux2.MUESTRA)
                                If Not lista Is Nothing Then
                                    If lista.Count > 0 Then
                                        Dim p As New dPetriscan
                                        Dim lectura1 As Integer = 0
                                        Dim lectura2 As Integer = 0
                                        Dim resultado As Integer = 0
                                        For Each paux3 In lista
                                            If paux3.DILUCION = 2 Then
                                                lectura1 = paux3.RB
                                            ElseIf paux3.DILUCION = 3 Then
                                                lectura2 = paux3.RB
                                            Else
                                                lectura2 = paux3.RB
                                            End If
                                        Next
                                        'si lectura1 y lectura2 son mayores que cero
                                        If lectura1 > 0 And lectura2 > 0 Then
                                            resultado = (lectura1 + lectura2) / 2 / 1000
                                            'si lectura1 y lectura2 son (TNTC) muy numeroso para contar
                                        ElseIf lectura1 < 0 And lectura2 < 0 Then
                                            If paux3.DILUCION = 3 Then
                                                'resultado >300
                                                resultado = 301
                                            ElseIf paux3.DILUCION = 4 Then
                                                'resultado >3000
                                                resultado = 3001
                                            End If
                                            'si lectura1 es TNTC y lectura2 es mayor que cero
                                        ElseIf lectura1 < 0 And lectura2 > 0 Then
                                            resultado = lectura2 / 1000
                                        Else
                                            resultado = -3
                                        End If
                                        fecha = paux3.FECHA
                                        fec = Format(fecha, "yyyy-MM-dd")
                                        p.FECHA = fec
                                        p.FICHA = paux3.FICHA
                                        p.MUESTRA = paux3.MUESTRA
                                        p.RB = resultado
                                        p.guardar()
                                    End If
                                End If
                            Next
                        End If
                    End If
                Next
            End If
        End If
        limpiar_petriaux()
    End Sub
    Private Sub limpiar_petriaux()

    End Sub
End Class