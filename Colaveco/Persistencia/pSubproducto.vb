Public Class pSubproducto
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dSubproducto = CType(o, dSubproducto)
        Dim sql As String = "INSERT INTO subproductos (id, ficha, fechasolicitud, fechaproceso, estafcoagpositivo, cf, mohosylevaduras, ct, ecoli, ecoli157, salmonella, listeriaspp, humedad, mgrasa, ph, cloruros, proteinas, enterobacterias, listeriaambiental, esporanaermesofilo, termofilos, psicrotrofos, rb, tablanutricional, listeriamonocitogenes, cenizas, salmonellapool, listeriapool, marca) VALUES (" & obj.ID & ", " & obj.FICHA & ",'" & obj.FECHASOLICITUD & "','" & obj.FECHAPROCESO & "', " & obj.ESTAFCOAGPOSITIVO & ", " & obj.CF & ", " & obj.MOHOSYLEVADURAS & "," & obj.CT & ", " & obj.ECOLI & ", " & obj.ECOLI157 & ", " & obj.SALMONELLA & ", " & obj.LISTERIASPP & ", " & obj.HUMEDAD & ", " & obj.MGRASA & ", " & obj.PH & "," & obj.CLORUROS & "," & obj.PROTEINAS & "," & obj.ENTEROBACTERIAS & "," & obj.LISTERIAAMBIENTAL & "," & obj.ESPORANAERMESOFILO & "," & obj.TERMOFILOS & "," & obj.PSICROTROFOS & "," & obj.RB & "," & obj.TABLANUTRICIONAL & "," & obj.LISTERIAMONOCITOGENES & "," & obj.CENIZAS & "," & obj.SALMONELLAPOOL & ", " & obj.LISTERIAPOOL & "," & obj.MARCA & ")"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'subproductos', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dSubproducto = CType(o, dSubproducto)
        Dim sql As String = "UPDATE subproductos SET ficha = " & obj.FICHA & ",  fechasolicitud ='" & obj.FECHASOLICITUD & "', fechaproceso ='" & obj.FECHAPROCESO & "',estafcoagpositivo=" & obj.ESTAFCOAGPOSITIVO & ",cf=" & obj.CF & ",mohosylevaduras=" & obj.MOHOSYLEVADURAS & ",ct=" & obj.CT & ",ecoli=" & obj.ECOLI & ",ecoli157=" & obj.ECOLI157 & ", salmonella=" & obj.SALMONELLA & ", listeriaspp=" & obj.LISTERIASPP & ", humedad=" & obj.HUMEDAD & ", mgrasa=" & obj.MGRASA & ",ph=" & obj.PH & ",cloruros=" & obj.CLORUROS & ", proteinas=" & obj.PROTEINAS & ",enterobacterias=" & obj.ENTEROBACTERIAS & ",listeriaambiental=" & obj.LISTERIAAMBIENTAL & ",esporanaermesofilo=" & obj.ESPORANAERMESOFILO & ",termofilos=" & obj.TERMOFILOS & ",psicrotrofos=" & obj.PSICROTROFOS & ",rb=" & obj.RB & ",tablanutricional=" & obj.TABLANUTRICIONAL & ",listeriamonocitogenes=" & obj.LISTERIAMONOCITOGENES & ",cenizas=" & obj.CENIZAS & ",salmonellapool=" & obj.SALMONELLAPOOL & ", listeriapool=" & obj.LISTERIAPOOL & ", marca=" & obj.MARCA & " WHERE ID = " & obj.ID

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'subproductos', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar2(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dSubproducto = CType(o, dSubproducto)
        Dim sql As String = "UPDATE subproductos SET fechaproceso ='" & obj.FECHAPROCESO & "' WHERE ficha = " & obj.ficha & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'subproductos', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dSubproducto = CType(o, dSubproducto)
        Dim sql As String = "DELETE FROM subproductos WHERE ficha = " & obj.FICHA & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'subproductos', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dSubproducto
        Dim obj As dSubproducto = CType(o, dSubproducto)
        Dim s As New dSubproducto
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, ficha, fechasolicitud, fechaproceso, estafcoagpositivo, cf, mohosylevaduras, ct, ecoli, ecoli157, salmonella, listeriaspp, humedad, mgrasa, ph, cloruros, proteinas, enterobacterias, listeriaambiental, esporanaermesofilo, termofilos, psicrotrofos, rb, tablanutricional,  listeriamonocitogenes, cenizas, salmonellapool, listeriapool, marca FROM subproductos WHERE ficha = " & obj.ID)

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                s.ID = CType(unaFila.Item(0), Long)
                s.ficha = CType(unaFila.Item(1), Long)
                s.FECHASOLICITUD = CType(unaFila.Item(2), String)
                s.FECHAPROCESO = CType(unaFila.Item(3), String)
                s.ESTAFCOAGPOSITIVO = CType(unaFila.Item(4), Integer)
                s.CF = CType(unaFila.Item(5), Integer)
                s.MOHOSYLEVADURAS = CType(unaFila.Item(6), Integer)
                s.CT = CType(unaFila.Item(7), Integer)
                s.ECOLI = CType(unaFila.Item(8), Integer)
                s.ECOLI157 = CType(unaFila.Item(9), Integer)
                s.SALMONELLA = CType(unaFila.Item(10), Integer)
                s.LISTERIASPP = CType(unaFila.Item(11), Integer)
                s.HUMEDAD = CType(unaFila.Item(12), Integer)
                s.MGRASA = CType(unaFila.Item(13), Integer)
                s.PH = CType(unaFila.Item(14), Integer)
                s.CLORUROS = CType(unaFila.Item(15), Integer)
                s.PROTEINAS = CType(unaFila.Item(16), Integer)
                s.ENTEROBACTERIAS = CType(unaFila.Item(17), Integer)
                s.LISTERIAAMBIENTAL = CType(unaFila.Item(18), Integer)
                s.ESPORANAERMESOFILO = CType(unaFila.Item(19), Integer)
                s.TERMOFILOS = CType(unaFila.Item(20), Integer)
                s.PSICROTROFOS = CType(unaFila.Item(21), Integer)
                s.RB = CType(unaFila.Item(22), Integer)
                s.TABLANUTRICIONAL = CType(unaFila.Item(23), Integer)
                s.LISTERIAMONOCITOGENES = CType(unaFila.Item(24), Integer)
                s.CENIZAS = CType(unaFila.Item(25), Integer)
                s.SALMONELLAPOOL = CType(unaFila.Item(26), Integer)
                s.LISTERIAPOOL = CType(unaFila.Item(27), Integer)
                s.MARCA = CType(unaFila.Item(28), Integer)
                Return s
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscarxsolicitud(ByVal o As Object) As dSubproducto
        Dim obj As dSubproducto = CType(o, dSubproducto)
        Dim s As New dSubproducto
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, ficha, fechasolicitud, fechaproceso, estafcoagpositivo, cf, mohosylevaduras, ct, ecoli, ecoli157, salmonella, listeriaspp, humedad, mgrasa, ph, cloruros, proteinas, enterobacterias, listeriaambiental, esporanaermesofilo, termofilos, psicrotrofos, rb, tablanutricional,  listeriamonocitogenes, cenizas, salmonellapool, listeriapool, marca FROM subproductos WHERE ficha = " & obj.FICHA & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                s.ID = CType(unaFila.Item(0), Long)
                s.FICHA = CType(unaFila.Item(1), Long)
                s.FECHASOLICITUD = CType(unaFila.Item(2), String)
                s.FECHAPROCESO = CType(unaFila.Item(3), String)
                s.ESTAFCOAGPOSITIVO = CType(unaFila.Item(4), Integer)
                s.CF = CType(unaFila.Item(5), Integer)
                s.MOHOSYLEVADURAS = CType(unaFila.Item(6), Integer)
                s.CT = CType(unaFila.Item(7), Integer)
                s.ECOLI = CType(unaFila.Item(8), Integer)
                s.ECOLI157 = CType(unaFila.Item(9), Integer)
                s.SALMONELLA = CType(unaFila.Item(10), Integer)
                s.LISTERIASPP = CType(unaFila.Item(11), Integer)
                s.HUMEDAD = CType(unaFila.Item(12), Integer)
                s.MGRASA = CType(unaFila.Item(13), Integer)
                s.PH = CType(unaFila.Item(14), Integer)
                s.CLORUROS = CType(unaFila.Item(15), Integer)
                s.PROTEINAS = CType(unaFila.Item(16), Integer)
                s.ENTEROBACTERIAS = CType(unaFila.Item(17), Integer)
                s.LISTERIAAMBIENTAL = CType(unaFila.Item(18), Integer)
                s.ESPORANAERMESOFILO = CType(unaFila.Item(19), Integer)
                s.TERMOFILOS = CType(unaFila.Item(20), Integer)
                s.PSICROTROFOS = CType(unaFila.Item(21), Integer)
                s.RB = CType(unaFila.Item(22), Integer)
                s.TABLANUTRICIONAL = CType(unaFila.Item(23), Integer)
                s.LISTERIAMONOCITOGENES = CType(unaFila.Item(24), Integer)
                s.CENIZAS = CType(unaFila.Item(25), Integer)
                s.SALMONELLAPOOL = CType(unaFila.Item(26), Integer)
                s.LISTERIAPOOL = CType(unaFila.Item(27), Integer)
                s.MARCA = CType(unaFila.Item(28), Integer)
                Return s
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, ficha, fechasolicitud, fechaproceso, estafcoagpositivo, cf, mohosylevaduras, ct, ecoli, ecoli157, salmonella, listeriaspp, humedad, mgrasa, ph, cloruros, proteinas, enterobacterias, listeriaambiental, esporanaermesofilo, termofilos, psicrotrofos, rb, tablanutricional, listeriamonocitogenes, cenizas, salmonellapool, listeriapool, marca FROM subproductos WHERE marca = 0 order by id desc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSubproducto
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FICHA = CType(unaFila.Item(1), Long)
                    s.FECHASOLICITUD = CType(unaFila.Item(2), String)
                    s.FECHAPROCESO = CType(unaFila.Item(3), String)
                    s.ESTAFCOAGPOSITIVO = CType(unaFila.Item(4), Integer)
                    s.CF = CType(unaFila.Item(5), Integer)
                    s.MOHOSYLEVADURAS = CType(unaFila.Item(6), Integer)
                    s.CT = CType(unaFila.Item(7), Integer)
                    s.ECOLI = CType(unaFila.Item(8), Integer)
                    s.ECOLI157 = CType(unaFila.Item(9), Integer)
                    s.SALMONELLA = CType(unaFila.Item(10), Integer)
                    s.LISTERIASPP = CType(unaFila.Item(11), Integer)
                    s.HUMEDAD = CType(unaFila.Item(12), Integer)
                    s.MGRASA = CType(unaFila.Item(13), Integer)
                    s.PH = CType(unaFila.Item(14), Integer)
                    s.CLORUROS = CType(unaFila.Item(15), Integer)
                    s.PROTEINAS = CType(unaFila.Item(16), Integer)
                    s.ENTEROBACTERIAS = CType(unaFila.Item(17), Integer)
                    s.LISTERIAAMBIENTAL = CType(unaFila.Item(18), Integer)
                    s.ESPORANAERMESOFILO = CType(unaFila.Item(19), Integer)
                    s.TERMOFILOS = CType(unaFila.Item(20), Integer)
                    s.PSICROTROFOS = CType(unaFila.Item(21), Integer)
                    s.RB = CType(unaFila.Item(22), Integer)
                    s.TABLANUTRICIONAL = CType(unaFila.Item(23), Integer)
                    s.LISTERIAMONOCITOGENES = CType(unaFila.Item(24), Integer)
                    s.CENIZAS = CType(unaFila.Item(25), Integer)
                    s.SALMONELLAPOOL = CType(unaFila.Item(26), Integer)
                    s.LISTERIAPOOL = CType(unaFila.Item(27), Integer)
                    s.MARCA = CType(unaFila.Item(28), Integer)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarfichas() As ArrayList
        Dim sql As String = "SELECT DISTINCT ficha FROM subproductos WHERE marca = 0 order by ficha asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSubproducto
                    s.ficha = CType(unaFila.Item(0), Long)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function listarporid(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, ficha, fechasolicitud, fechaproceso, estafcoagpositivo, cf, mohosylevaduras, ct, ecoli, ecoli157, salmonella, listeriaspp, humedad, mgrasa, ph, cloruros, proteinas, enterobacterias, listeriaambiental, esporanaermesofilo, termofilos, psicrotrofos, rb, tablanutricional, listeriamonocitogenes, cenizas, salmonellapool, listeriapool, marca FROM subproductos where ficha = " & texto & "")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSubproducto
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FICHA = CType(unaFila.Item(1), Long)
                    s.FECHASOLICITUD = CType(unaFila.Item(2), String)
                    s.FECHAPROCESO = CType(unaFila.Item(3), String)
                    s.ESTAFCOAGPOSITIVO = CType(unaFila.Item(4), Integer)
                    s.CF = CType(unaFila.Item(5), Integer)
                    s.MOHOSYLEVADURAS = CType(unaFila.Item(6), Integer)
                    s.CT = CType(unaFila.Item(7), Integer)
                    s.ECOLI = CType(unaFila.Item(8), Integer)
                    s.ECOLI157 = CType(unaFila.Item(9), Integer)
                    s.SALMONELLA = CType(unaFila.Item(10), Integer)
                    s.LISTERIASPP = CType(unaFila.Item(11), Integer)
                    s.HUMEDAD = CType(unaFila.Item(12), Integer)
                    s.MGRASA = CType(unaFila.Item(13), Integer)
                    s.PH = CType(unaFila.Item(14), Integer)
                    s.CLORUROS = CType(unaFila.Item(15), Integer)
                    s.PROTEINAS = CType(unaFila.Item(16), Integer)
                    s.ENTEROBACTERIAS = CType(unaFila.Item(17), Integer)
                    s.LISTERIAAMBIENTAL = CType(unaFila.Item(18), Integer)
                    s.ESPORANAERMESOFILO = CType(unaFila.Item(19), Integer)
                    s.TERMOFILOS = CType(unaFila.Item(20), Integer)
                    s.PSICROTROFOS = CType(unaFila.Item(21), Integer)
                    s.RB = CType(unaFila.Item(22), Integer)
                    s.TABLANUTRICIONAL = CType(unaFila.Item(23), Integer)
                    s.LISTERIAMONOCITOGENES = CType(unaFila.Item(24), Integer)
                    s.CENIZAS = CType(unaFila.Item(25), Integer)
                    s.SALMONELLAPOOL = CType(unaFila.Item(26), Integer)
                    s.LISTERIAPOOL = CType(unaFila.Item(27), Integer)
                    s.MARCA = CType(unaFila.Item(28), Integer)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function


    Public Function listarporsolicitud(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, ficha, fechasolicitud, fechaproceso, estafcoagpositivo, cf, mohosylevaduras, ct, ecoli, ecoli157, salmonella, listeriaspp, humedad, mgrasa, ph, cloruros, proteinas, enterobacterias, listeriaambiental, esporanaermesofilo, termofilos, psicrotrofos, rb, tablanutricional, listeriamonocitogenes, cenizas, salmonellapool, listeriapool, marca FROM subproductos where marca = 0 and ficha = " & texto)
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSubproducto
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FICHA = CType(unaFila.Item(1), Long)
                    s.FECHASOLICITUD = CType(unaFila.Item(2), String)
                    s.FECHAPROCESO = CType(unaFila.Item(3), String)
                    s.ESTAFCOAGPOSITIVO = CType(unaFila.Item(4), Integer)
                    s.CF = CType(unaFila.Item(5), Integer)
                    s.MOHOSYLEVADURAS = CType(unaFila.Item(6), Integer)
                    s.CT = CType(unaFila.Item(7), Integer)
                    s.ECOLI = CType(unaFila.Item(8), Integer)
                    s.ECOLI157 = CType(unaFila.Item(9), Integer)
                    s.SALMONELLA = CType(unaFila.Item(10), Integer)
                    s.LISTERIASPP = CType(unaFila.Item(11), Integer)
                    s.HUMEDAD = CType(unaFila.Item(12), Integer)
                    s.MGRASA = CType(unaFila.Item(13), Integer)
                    s.PH = CType(unaFila.Item(14), Integer)
                    s.CLORUROS = CType(unaFila.Item(15), Integer)
                    s.PROTEINAS = CType(unaFila.Item(16), Integer)
                    s.ENTEROBACTERIAS = CType(unaFila.Item(17), Integer)
                    s.LISTERIAAMBIENTAL = CType(unaFila.Item(18), Integer)
                    s.ESPORANAERMESOFILO = CType(unaFila.Item(19), Integer)
                    s.TERMOFILOS = CType(unaFila.Item(20), Integer)
                    s.PSICROTROFOS = CType(unaFila.Item(21), Integer)
                    s.RB = CType(unaFila.Item(22), Integer)
                    s.TABLANUTRICIONAL = CType(unaFila.Item(23), Integer)
                    s.LISTERIAMONOCITOGENES = CType(unaFila.Item(24), Integer)
                    s.CENIZAS = CType(unaFila.Item(25), Integer)
                    s.SALMONELLAPOOL = CType(unaFila.Item(26), Integer)
                    s.LISTERIAPOOL = CType(unaFila.Item(27), Integer)
                    s.MARCA = CType(unaFila.Item(28), Integer)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarporsolicitud2(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, ficha, fechasolicitud, fechaproceso, estafcoagpositivo, cf, mohosylevaduras, ct, ecoli, ecoli157, salmonella, listeriaspp, humedad, mgrasa, ph, cloruros, proteinas, enterobacterias, listeriaambiental, esporanaermesofilo, termofilos, psicrotrofos, rb, tablanutricional, listeriamonocitogenes, cenizas, salmonellapool, listeriapool, marca FROM subproductos where marca = 1 and ficha = " & texto)
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSubproducto
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FICHA = CType(unaFila.Item(1), Long)
                    s.FECHASOLICITUD = CType(unaFila.Item(2), String)
                    s.FECHAPROCESO = CType(unaFila.Item(3), String)
                    s.ESTAFCOAGPOSITIVO = CType(unaFila.Item(4), Integer)
                    s.CF = CType(unaFila.Item(5), Integer)
                    s.MOHOSYLEVADURAS = CType(unaFila.Item(6), Integer)
                    s.CT = CType(unaFila.Item(7), Integer)
                    s.ECOLI = CType(unaFila.Item(8), Integer)
                    s.ECOLI157 = CType(unaFila.Item(9), Integer)
                    s.SALMONELLA = CType(unaFila.Item(10), Integer)
                    s.LISTERIASPP = CType(unaFila.Item(11), Integer)
                    s.HUMEDAD = CType(unaFila.Item(12), Integer)
                    s.MGRASA = CType(unaFila.Item(13), Integer)
                    s.PH = CType(unaFila.Item(14), Integer)
                    s.CLORUROS = CType(unaFila.Item(15), Integer)
                    s.PROTEINAS = CType(unaFila.Item(16), Integer)
                    s.ENTEROBACTERIAS = CType(unaFila.Item(17), Integer)
                    s.LISTERIAAMBIENTAL = CType(unaFila.Item(18), Integer)
                    s.ESPORANAERMESOFILO = CType(unaFila.Item(19), Integer)
                    s.TERMOFILOS = CType(unaFila.Item(20), Integer)
                    s.PSICROTROFOS = CType(unaFila.Item(21), Integer)
                    s.RB = CType(unaFila.Item(22), Integer)
                    s.TABLANUTRICIONAL = CType(unaFila.Item(23), Integer)
                    s.LISTERIAMONOCITOGENES = CType(unaFila.Item(24), Integer)
                    s.CENIZAS = CType(unaFila.Item(25), Integer)
                    s.SALMONELLAPOOL = CType(unaFila.Item(26), Integer)
                    s.LISTERIAPOOL = CType(unaFila.Item(27), Integer)
                    s.MARCA = CType(unaFila.Item(28), Integer)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarporfecha(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim sql As String = ("SELECT id, ficha, fechasolicitud, fechaproceso, estafcoagpositivo, cf, mohosylevaduras, ct, ecoli, ecoli157, salmonella, listeriaspp, humedad, mgrasa, ph, cloruros, proteinas, enterobacterias, listeriaambiental, esporanaermesofilo, termofilos, psicrotrofos, rb, tablanutricional, listeriamonocitogenes, cenizas, salmonellapool, listeriapool, marca FROM subproductos where fechaingreso BETWEEN '" & fechadesde & "' And '" & fechahasta & "'")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSubproducto
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FICHA = CType(unaFila.Item(1), Long)
                    s.FECHASOLICITUD = CType(unaFila.Item(2), String)
                    s.FECHAPROCESO = CType(unaFila.Item(3), String)
                    s.ESTAFCOAGPOSITIVO = CType(unaFila.Item(4), Integer)
                    s.CF = CType(unaFila.Item(5), Integer)
                    s.MOHOSYLEVADURAS = CType(unaFila.Item(6), Integer)
                    s.CT = CType(unaFila.Item(7), Integer)
                    s.ECOLI = CType(unaFila.Item(8), Integer)
                    s.ECOLI157 = CType(unaFila.Item(9), Integer)
                    s.SALMONELLA = CType(unaFila.Item(10), Integer)
                    s.LISTERIASPP = CType(unaFila.Item(11), Integer)
                    s.HUMEDAD = CType(unaFila.Item(12), Integer)
                    s.MGRASA = CType(unaFila.Item(13), Integer)
                    s.PH = CType(unaFila.Item(14), Integer)
                    s.CLORUROS = CType(unaFila.Item(15), Integer)
                    s.PROTEINAS = CType(unaFila.Item(16), Integer)
                    s.ENTEROBACTERIAS = CType(unaFila.Item(17), Integer)
                    s.LISTERIAAMBIENTAL = CType(unaFila.Item(18), Integer)
                    s.ESPORANAERMESOFILO = CType(unaFila.Item(19), Integer)
                    s.TERMOFILOS = CType(unaFila.Item(20), Integer)
                    s.PSICROTROFOS = CType(unaFila.Item(21), Integer)
                    s.RB = CType(unaFila.Item(22), Integer)
                    s.TABLANUTRICIONAL = CType(unaFila.Item(23), Integer)
                    s.LISTERIAMONOCITOGENES = CType(unaFila.Item(24), Integer)
                    s.CENIZAS = CType(unaFila.Item(25), Integer)
                    s.SALMONELLAPOOL = CType(unaFila.Item(26), Integer)
                    s.LISTERIAPOOL = CType(unaFila.Item(27), Integer)
                    s.MARCA = CType(unaFila.Item(28), Integer)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
