Public Class pTiempos
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dTiempos = CType(o, dTiempos)
        Dim sql As String = "INSERT INTO tiempos (control, calidad, agua, antibiograma, pal, parasitologia, productos, serologia, patologia, ambiental, lactometros, nutricion, otros, suelos, serologia_brucelosis, serologia_otros, sp_salmonella_listeria, sp_mohos_levaduras, esporulados, brucelosis_leche, efluentes) VALUES (" & obj.CONTROL & "," & obj.CALIDAD & "," & obj.AGUA & "," & obj.ANTIBIOGRAMA & ", ," & obj.PAL & "," & obj.PARASITOLOGIA & "," & obj.PRODUCTOS & "," & obj.SEROLOGIA_LEUCOSIS & "," & obj.PATOLOGIA & "," & obj.AMBIENTAL & "," & obj.LACTOMETROS & "," & obj.NUTRICION & "," & obj.OTROS & "," & obj.SUELOS & "," & obj.SEROLOGIA_BRUCELOSIS & "," & obj.SEROLOGIA_OTROS & "," & obj.SP_SALMONELLA_LISTERIA & "," & obj.SP_MOHOS_LEVADURAS & "," & obj.ESPORULADOS & "," & obj.BRUCELOSIS_LECHE & "," & obj.EFLUENTES & ")"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'tiempos', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dTiempos = CType(o, dTiempos)
        Dim sql As String = "UPDATE tiempos SET control=" & obj.CONTROL & ", calidad = " & obj.CALIDAD & ", agua = " & obj.AGUA & ", antibiograma = " & obj.ANTIBIOGRAMA & ", pal = " & obj.PAL & ", parasitologia = " & obj.PARASITOLOGIA & ", productos = " & obj.PRODUCTOS & ", serologia = " & obj.SEROLOGIA_LEUCOSIS & ", patologia = " & obj.PATOLOGIA & ", ambiental = " & obj.AMBIENTAL & ", lactometros = " & obj.LACTOMETROS & ", nutricion = " & obj.NUTRICION & ", otros = " & obj.OTROS & ", suelos = " & obj.SUELOS & ", serologia_brucelosis = " & obj.SEROLOGIA_BRUCELOSIS & ", serologia_otros = " & obj.SEROLOGIA_OTROS & ", sp_salmonella_listeria = " & obj.SP_SALMONELLA_LISTERIA & ", sp_mohos_levaduras = " & obj.SP_MOHOS_LEVADURAS & ", esporulados = " & obj.ESPORULADOS & ", brucelosis_leche = " & obj.BRUCELOSIS_LECHE & ", efluentes = " & obj.EFLUENTES & " "

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'tiempos', 'modificación', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)


        Return EjecutarTransaccion(lista)
    End Function

    Public Function buscar(ByVal o As Object) As dTiempos
        Dim obj As dTiempos = CType(o, dTiempos)
        Dim l As New dTiempos
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT control, calidad, agua, antibiograma, pal, parasitologia, productos, serologia, patologia, ambiental, lactometros, nutricion, otros, suelos, serologia_brucelosis, serologia_otros, sp_salmonella_listeria, sp_mohos_levaduras, esporulados, brucelosis_leche, efluentes FROM tiempos ")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                l.CONTROL = CType(unaFila.Item(0), Integer)
                l.CALIDAD = CType(unaFila.Item(1), Integer)
                l.AGUA = CType(unaFila.Item(2), Integer)
                l.ANTIBIOGRAMA = CType(unaFila.Item(3), Integer)
                l.PAL = CType(unaFila.Item(4), Integer)
                l.PARASITOLOGIA = CType(unaFila.Item(5), Integer)
                l.PRODUCTOS = CType(unaFila.Item(6), Integer)
                l.SEROLOGIA_LEUCOSIS = CType(unaFila.Item(7), Integer)
                l.PATOLOGIA = CType(unaFila.Item(8), Integer)
                l.AMBIENTAL = CType(unaFila.Item(9), Integer)
                l.LACTOMETROS = CType(unaFila.Item(10), Integer)
                l.NUTRICION = CType(unaFila.Item(11), Integer)
                l.OTROS = CType(unaFila.Item(12), Integer)
                l.SUELOS = CType(unaFila.Item(13), Integer)
                l.SEROLOGIA_BRUCELOSIS = CType(unaFila.Item(14), Integer)
                l.SEROLOGIA_OTROS = CType(unaFila.Item(15), Integer)
                l.SP_SALMONELLA_LISTERIA = CType(unaFila.Item(16), Integer)
                l.SP_MOHOS_LEVADURAS = CType(unaFila.Item(17), Integer)
                l.ESPORULADOS = CType(unaFila.Item(18), Integer)
                l.BRUCELOSIS_LECHE = CType(unaFila.Item(19), Integer)
                l.EFLUENTES = CType(unaFila.Item(20), Integer)
                Return l
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT control, calidad, agua, antibiograma, pal, parasitologia, productos, serologia, patologia, ambiental, lactometros, nutricion, otros, suelos, serologia_brucelosis, serologia_otros, sp_salmonella_listeria, sp_mohos_levaduras, esporulados, brucelosis_leche, efluentes FROM tiempos"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dTiempos
                    l.CONTROL = CType(unaFila.Item(0), Integer)
                    l.CALIDAD = CType(unaFila.Item(1), Integer)
                    l.AGUA = CType(unaFila.Item(2), Integer)
                    l.ANTIBIOGRAMA = CType(unaFila.Item(3), Integer)
                    l.PAL = CType(unaFila.Item(4), Integer)
                    l.PARASITOLOGIA = CType(unaFila.Item(5), Integer)
                    l.PRODUCTOS = CType(unaFila.Item(6), Integer)
                    l.SEROLOGIA_LEUCOSIS = CType(unaFila.Item(7), Integer)
                    l.PATOLOGIA = CType(unaFila.Item(8), Integer)
                    l.AMBIENTAL = CType(unaFila.Item(9), Integer)
                    l.LACTOMETROS = CType(unaFila.Item(10), Integer)
                    l.NUTRICION = CType(unaFila.Item(11), Integer)
                    l.OTROS = CType(unaFila.Item(12), Integer)
                    l.SUELOS = CType(unaFila.Item(13), Integer)
                    l.SEROLOGIA_BRUCELOSIS = CType(unaFila.Item(14), Integer)
                    l.SEROLOGIA_OTROS = CType(unaFila.Item(15), Integer)
                    l.SP_SALMONELLA_LISTERIA = CType(unaFila.Item(16), Integer)
                    l.SP_MOHOS_LEVADURAS = CType(unaFila.Item(17), Integer)
                    l.ESPORULADOS = CType(unaFila.Item(18), Integer)
                    l.BRUCELOSIS_LECHE = CType(unaFila.Item(19), Integer)
                    l.EFLUENTES = CType(unaFila.Item(20), Integer)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
