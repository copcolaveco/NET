Public Class pAmbiental
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dAmbiental = CType(o, dAmbiental)
        Dim sql As String = "INSERT INTO ambiental (id, ficha, fechasolicitud, fechaproceso, muestra, detallemuestra, observaciones, estadomuestra, listambiental, listambiental2, listmono, listeriaspp, listeriaspp2, estafcoagpositivo, estafcoagpositivo2, salmonella, enterobacterias, enterobacterias2, ecoli, ecoli2, rb, mohos, mohos2, levaduras, levaduras2, ct, ct2, cf, cf2, pseudomonaspp, pseudomonaspp2, operador, marca) VALUES (" & obj.ID & ", " & obj.FICHA & ",'" & obj.FECHASOLICITUD & "', '" & obj.FECHAPROCESO & "','" & obj.IDMUESTRA & "','" & obj.DETALLEMUESTRA & "','" & obj.OBSERVACIONES & "','" & obj.ESTADOMUESTRA & "', " & obj.LISTERIAAMBIENTAL & ",'" & obj.LISTERIAAMBIENTAL2 & "'," & obj.LISTERIAMONOCITOGENES & "," & obj.LISTERIASPP & ",'" & obj.LISTERIASPP2 & "'," & obj.ESTAFCOAGPOSITIVO & ",'" & obj.ESTAFCOAGPOSITIVO2 & "'," & obj.SALMONELLA & "," & obj.ENTEROBACTERIAS & ",'" & obj.ENTEROBACTERIAS2 & "', " & obj.ECOLI & ",'" & obj.ECOLI2 & "', '" & obj.RB & "', " & obj.MOHOS & ",'" & obj.MOHOS2 & "'," & obj.LEVADURAS & ",'" & obj.LEVADURAS2 & "', '" & obj.CT & "', '" & obj.CT2 & "', '" & obj.CF & "', '" & obj.CF2 & "', '" & obj.PSEUDOMONASPP & "', '" & obj.PSEUDOMONASPP2 & "'," & obj.OPERADOR & "," & obj.MARCA & ")"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'ambiental', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dAmbiental = CType(o, dAmbiental)
        Dim sql As String = "UPDATE ambiental SET ficha=" & obj.FICHA & ", fechasolicitud='" & obj.FECHASOLICITUD & "', fechaproceso='" & obj.FECHAPROCESO & "', muestra='" & obj.IDMUESTRA & "', detallemuestra='" & obj.DETALLEMUESTRA & "', observaciones='" & obj.OBSERVACIONES & "', estadomuestra='" & obj.ESTADOMUESTRA & "', listambiental=" & obj.LISTERIAAMBIENTAL & ", listambiental2='" & obj.LISTERIAAMBIENTAL2 & "', listmono=" & obj.LISTERIAMONOCITOGENES & ",listeriaspp=" & obj.LISTERIASPP & ",listeriaspp2='" & obj.LISTERIASPP2 & "',estafcoagpositivo=" & obj.ESTAFCOAGPOSITIVO & ",estafcoagpositivo2='" & obj.ESTAFCOAGPOSITIVO2 & "', salmonella=" & obj.SALMONELLA & ", enterobacterias=" & obj.ENTEROBACTERIAS & ", enterobacterias2='" & obj.ENTEROBACTERIAS2 & "', ecoli=" & obj.ECOLI & ", ecoli2='" & obj.ECOLI2 & "', rb='" & obj.RB & "', mohos=" & obj.MOHOS & ", mohos2='" & obj.MOHOS2 & "', levaduras=" & obj.LEVADURAS & ", levaduras2='" & obj.LEVADURAS2 & "', ct='" & obj.CT & "', ct2='" & obj.CT2 & "', cf='" & obj.CF & "', cf2='" & obj.CF2 & "', pseudomonaspp='" & obj.PSEUDOMONASPP & "', pseudomonaspp2='" & obj.PSEUDOMONASPP2 & "',operador=" & obj.OPERADOR & ", marca=" & obj.MARCA & " WHERE ID = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'ambiental', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar2(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dAmbiental = CType(o, dAmbiental)
        Dim sql As String = "UPDATE ambiental SET marca=" & obj.MARCA & " WHERE ID = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'ambiental', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dAmbiental = CType(o, dAmbiental)
        Dim sql As String = "DELETE FROM ambiental WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'ambiental', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar2(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dAmbiental = CType(o, dAmbiental)
        Dim sql As String = "DELETE FROM ambiental WHERE ficha = " & obj.FICHA & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'ambiental', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dAmbiental
        Dim obj As dAmbiental = CType(o, dAmbiental)
        Dim a As New dAmbiental
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, ficha, fechasolicitud, fechaproceso, muestra, detallemuestra, observaciones, estadomuestra, listambiental, listambiental2, listmono, listeriaspp, listeriaspp2, estafcoagpositivo, estafcoagpositivo2, salmonella, enterobacterias, enterobacterias2, ecoli, ecoli2, rb, mohos, mohos2, levaduras, levaduras2, ct, ct2, cf, cf2, pseudomonaspp, pseudomonaspp2, operador, marca FROM ambiental WHERE ficha = " & obj.FICHA & "")
            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                a.ID = CType(unaFila.Item(0), Long)
                a.FICHA = CType(unaFila.Item(1), Long)
                a.FECHASOLICITUD = CType(unaFila.Item(2), String)
                a.FECHAPROCESO = CType(unaFila.Item(3), String)
                a.IDMUESTRA = CType(unaFila.Item(4), String)
                a.DETALLEMUESTRA = CType(unaFila.Item(5), String)
                a.OBSERVACIONES = CType(unaFila.Item(6), String)
                a.ESTADOMUESTRA = CType(unaFila.Item(7), String)
                a.LISTERIAAMBIENTAL = CType(unaFila.Item(8), Integer)
                a.LISTERIAAMBIENTAL2 = CType(unaFila.Item(9), String)
                a.LISTERIAMONOCITOGENES = CType(unaFila.Item(10), Integer)
                a.LISTERIASPP = CType(unaFila.Item(11), Integer)
                a.LISTERIASPP2 = CType(unaFila.Item(12), String)
                a.ESTAFCOAGPOSITIVO = CType(unaFila.Item(13), Integer)
                a.ESTAFCOAGPOSITIVO2 = CType(unaFila.Item(14), String)
                a.SALMONELLA = CType(unaFila.Item(15), Integer)
                a.ENTEROBACTERIAS = CType(unaFila.Item(16), Integer)
                a.ENTEROBACTERIAS2 = CType(unaFila.Item(17), String)
                a.ECOLI = CType(unaFila.Item(18), Integer)
                a.ECOLI2 = CType(unaFila.Item(19), String)
                a.RB = CType(unaFila.Item(20), String)
                a.MOHOS = CType(unaFila.Item(21), Integer)
                a.MOHOS2 = CType(unaFila.Item(22), String)
                a.LEVADURAS = CType(unaFila.Item(23), Integer)
                a.LEVADURAS2 = CType(unaFila.Item(24), String)
                a.CT = CType(unaFila.Item(25), Integer)
                a.CT2 = CType(unaFila.Item(26), String)
                a.CF = CType(unaFila.Item(27), Integer)
                a.CF2 = CType(unaFila.Item(28), String)
                a.PSEUDOMONASPP = CType(unaFila.Item(29), Integer)
                a.PSEUDOMONASPP2 = CType(unaFila.Item(30), String)
                a.OPERADOR = CType(unaFila.Item(31), Integer)
                a.MARCA = CType(unaFila.Item(32), Integer)
                Return a
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscarxsolicitud(ByVal o As Object) As dAmbiental
        Dim obj As dAmbiental = CType(o, dAmbiental)
        Dim a As New dAmbiental
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, ficha, fechasolicitud, fechaproceso, muestra, detallemuestra, observaciones, estadomuestra, listambiental, listambiental2, listmono, listeriaspp, listeriaspp2, estafcoagpositivo, estafcoagpositivo2, salmonella, enterobacterias, enterobacterias2, ecoli, ecoli2, rb, mohos, mohos2, levaduras, levaduras2, ct, ct2, cf, cf2, pseudomonaspp, pseudomonaspp2, operador, marca FROM ambiental WHERE ficha = " & obj.FICHA & "")
            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                a.ID = CType(unaFila.Item(0), Long)
                a.FICHA = CType(unaFila.Item(1), Long)
                a.FECHASOLICITUD = CType(unaFila.Item(2), String)
                a.FECHAPROCESO = CType(unaFila.Item(3), String)
                a.IDMUESTRA = CType(unaFila.Item(4), String)
                a.DETALLEMUESTRA = CType(unaFila.Item(5), String)
                a.OBSERVACIONES = CType(unaFila.Item(6), String)
                a.ESTADOMUESTRA = CType(unaFila.Item(7), String)
                a.LISTERIAAMBIENTAL = CType(unaFila.Item(8), Integer)
                a.LISTERIAAMBIENTAL2 = CType(unaFila.Item(9), String)
                a.LISTERIAMONOCITOGENES = CType(unaFila.Item(10), Integer)
                a.LISTERIASPP = CType(unaFila.Item(11), Integer)
                a.LISTERIASPP2 = CType(unaFila.Item(12), String)
                a.ESTAFCOAGPOSITIVO = CType(unaFila.Item(13), Integer)
                a.ESTAFCOAGPOSITIVO2 = CType(unaFila.Item(14), String)
                a.SALMONELLA = CType(unaFila.Item(15), Integer)
                a.ENTEROBACTERIAS = CType(unaFila.Item(16), Integer)
                a.ENTEROBACTERIAS2 = CType(unaFila.Item(17), String)
                a.ECOLI = CType(unaFila.Item(18), Integer)
                a.ECOLI2 = CType(unaFila.Item(19), String)
                a.RB = CType(unaFila.Item(20), String)
                a.MOHOS = CType(unaFila.Item(21), Integer)
                a.MOHOS2 = CType(unaFila.Item(22), String)
                a.LEVADURAS = CType(unaFila.Item(23), Integer)
                a.LEVADURAS2 = CType(unaFila.Item(24), String)
                a.CT = CType(unaFila.Item(25), Integer)
                a.CT2 = CType(unaFila.Item(26), String)
                a.CF = CType(unaFila.Item(27), Integer)
                a.CF2 = CType(unaFila.Item(28), String)
                a.PSEUDOMONASPP = CType(unaFila.Item(29), Integer)
                a.PSEUDOMONASPP2 = CType(unaFila.Item(30), String)
                a.OPERADOR = CType(unaFila.Item(31), Integer)
                a.MARCA = CType(unaFila.Item(32), Integer)
                Return a
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList

        Dim sql As String = "SELECT id, ficha, fechasolicitud, fechaproceso, muestra, detallemuestra, observaciones, estadomuestra, listambiental, listambiental2, listmono, listeriaspp, listeriaspp2, estafcoagpositivo, estafcoagpositivo2, salmonella, enterobacterias, enterobacterias2, ecoli, ecoli2, rb, mohos, mohos2, levaduras, levaduras2, ct, ct2, cf, cf2, pseudomonaspp, pseudomonaspp2, operador, marca FROM ambiental WHERE marca = 0 order by id desc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim a As New dAmbiental
                    a.ID = CType(unaFila.Item(0), Long)
                    a.FICHA = CType(unaFila.Item(1), Long)
                    a.FECHASOLICITUD = CType(unaFila.Item(2), String)
                    a.FECHAPROCESO = CType(unaFila.Item(3), String)
                    a.IDMUESTRA = CType(unaFila.Item(4), String)
                    a.DETALLEMUESTRA = CType(unaFila.Item(5), String)
                    a.OBSERVACIONES = CType(unaFila.Item(6), String)
                    a.ESTADOMUESTRA = CType(unaFila.Item(7), String)
                    a.LISTERIAAMBIENTAL = CType(unaFila.Item(8), Integer)
                    a.LISTERIAAMBIENTAL2 = CType(unaFila.Item(9), String)
                    a.LISTERIAMONOCITOGENES = CType(unaFila.Item(10), Integer)
                    a.LISTERIASPP = CType(unaFila.Item(11), Integer)
                    a.LISTERIASPP2 = CType(unaFila.Item(12), String)
                    a.ESTAFCOAGPOSITIVO = CType(unaFila.Item(13), Integer)
                    a.ESTAFCOAGPOSITIVO2 = CType(unaFila.Item(14), String)
                    a.SALMONELLA = CType(unaFila.Item(15), Integer)
                    a.ENTEROBACTERIAS = CType(unaFila.Item(16), Integer)
                    a.ENTEROBACTERIAS2 = CType(unaFila.Item(17), String)
                    a.ECOLI = CType(unaFila.Item(18), Integer)
                    a.ECOLI2 = CType(unaFila.Item(19), String)
                    a.RB = CType(unaFila.Item(20), String)
                    a.MOHOS = CType(unaFila.Item(21), Integer)
                    a.MOHOS2 = CType(unaFila.Item(22), String)
                    a.LEVADURAS = CType(unaFila.Item(23), Integer)
                    a.LEVADURAS2 = CType(unaFila.Item(24), String)
                    a.CT = CType(unaFila.Item(25), Integer)
                    a.CT2 = CType(unaFila.Item(26), String)
                    a.CF = CType(unaFila.Item(27), Integer)
                    a.CF2 = CType(unaFila.Item(28), String)
                    a.PSEUDOMONASPP = CType(unaFila.Item(29), Integer)
                    a.PSEUDOMONASPP2 = CType(unaFila.Item(30), String)
                    a.OPERADOR = CType(unaFila.Item(31), Integer)
                    a.MARCA = CType(unaFila.Item(32), Integer)
                    Lista.Add(a)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarfichas() As ArrayList
        Dim sql As String = "SELECT DISTINCT ficha FROM ambiental WHERE marca = 0 order by ficha asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim a As New dAmbiental
                    a.FICHA = CType(unaFila.Item(0), Long)
                    Lista.Add(a)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function listarporid(ByVal texto As Long) As ArrayList
        Dim sql As String = "SELECT id, ficha, fechasolicitud, fechaproceso, muestra, detallemuestra, observaciones, estadomuestra, listambiental, listambiental2, listmono, listeriaspp, listeriaspp2, estafcoagpositivo, estafcoagpositivo2, salmonella, enterobacterias, enterobacterias2, ecoli, ecoli2, rb, mohos, mohos2, levaduras, levaduras2, ct, ct2, cf, cf2, pseudomonaspp, pseudomonaspp2, operador, marca FROM ambiental where ficha = " & texto & ""
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(Sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim a As New dAmbiental
                    a.ID = CType(unaFila.Item(0), Long)
                    a.FICHA = CType(unaFila.Item(1), Long)
                    a.FECHASOLICITUD = CType(unaFila.Item(2), String)
                    a.FECHAPROCESO = CType(unaFila.Item(3), String)
                    a.IDMUESTRA = CType(unaFila.Item(4), String)
                    a.DETALLEMUESTRA = CType(unaFila.Item(5), String)
                    a.OBSERVACIONES = CType(unaFila.Item(6), String)
                    a.ESTADOMUESTRA = CType(unaFila.Item(7), String)
                    a.LISTERIAAMBIENTAL = CType(unaFila.Item(8), Integer)
                    a.LISTERIAAMBIENTAL2 = CType(unaFila.Item(9), String)
                    a.LISTERIAMONOCITOGENES = CType(unaFila.Item(10), Integer)
                    a.LISTERIASPP = CType(unaFila.Item(11), Integer)
                    a.LISTERIASPP2 = CType(unaFila.Item(12), String)
                    a.ESTAFCOAGPOSITIVO = CType(unaFila.Item(13), Integer)
                    a.ESTAFCOAGPOSITIVO2 = CType(unaFila.Item(14), String)
                    a.SALMONELLA = CType(unaFila.Item(15), Integer)
                    a.ENTEROBACTERIAS = CType(unaFila.Item(16), Integer)
                    a.ENTEROBACTERIAS2 = CType(unaFila.Item(17), String)
                    a.ECOLI = CType(unaFila.Item(18), Integer)
                    a.ECOLI2 = CType(unaFila.Item(19), String)
                    a.RB = CType(unaFila.Item(20), String)
                    a.MOHOS = CType(unaFila.Item(21), Integer)
                    a.MOHOS2 = CType(unaFila.Item(22), String)
                    a.LEVADURAS = CType(unaFila.Item(23), Integer)
                    a.LEVADURAS2 = CType(unaFila.Item(24), String)
                    a.CT = CType(unaFila.Item(25), Integer)
                    a.CT2 = CType(unaFila.Item(26), String)
                    a.CF = CType(unaFila.Item(27), Integer)
                    a.CF2 = CType(unaFila.Item(28), String)
                    a.PSEUDOMONASPP = CType(unaFila.Item(29), Integer)
                    a.PSEUDOMONASPP2 = CType(unaFila.Item(30), String)
                    a.OPERADOR = CType(unaFila.Item(31), Integer)
                    a.MARCA = CType(unaFila.Item(32), Integer)
                    Lista.Add(a)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function


    Public Function listarporsolicitud(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, ficha, fechasolicitud, fechaproceso, muestra, detallemuestra, observaciones, estadomuestra, listambiental, listambiental2, listmono, listeriaspp, listeriaspp2, estafcoagpositivo, estafcoagpositivo2, salmonella, enterobacterias, enterobacterias2, ecoli, ecoli2, rb, mohos, mohos2, levaduras, levaduras2, ct, ct2, cf, cf2, pseudomonaspp, pseudomonaspp2, operador, marca FROM ambiental where marca = 0 and ficha = " & texto & "")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim a As New dAmbiental
                    a.ID = CType(unaFila.Item(0), Long)
                    a.FICHA = CType(unaFila.Item(1), Long)
                    a.FECHASOLICITUD = CType(unaFila.Item(2), String)
                    a.FECHAPROCESO = CType(unaFila.Item(3), String)
                    a.IDMUESTRA = CType(unaFila.Item(4), String)
                    a.DETALLEMUESTRA = CType(unaFila.Item(5), String)
                    a.OBSERVACIONES = CType(unaFila.Item(6), String)
                    a.ESTADOMUESTRA = CType(unaFila.Item(7), String)
                    a.LISTERIAAMBIENTAL = CType(unaFila.Item(8), Integer)
                    a.LISTERIAAMBIENTAL2 = CType(unaFila.Item(9), String)
                    a.LISTERIAMONOCITOGENES = CType(unaFila.Item(10), Integer)
                    a.LISTERIASPP = CType(unaFila.Item(11), Integer)
                    a.LISTERIASPP2 = CType(unaFila.Item(12), String)
                    a.ESTAFCOAGPOSITIVO = CType(unaFila.Item(13), Integer)
                    a.ESTAFCOAGPOSITIVO2 = CType(unaFila.Item(14), String)
                    a.SALMONELLA = CType(unaFila.Item(15), Integer)
                    a.ENTEROBACTERIAS = CType(unaFila.Item(16), Integer)
                    a.ENTEROBACTERIAS2 = CType(unaFila.Item(17), String)
                    a.ECOLI = CType(unaFila.Item(18), Integer)
                    a.ECOLI2 = CType(unaFila.Item(19), String)
                    a.RB = CType(unaFila.Item(20), String)
                    a.MOHOS = CType(unaFila.Item(21), Integer)
                    a.MOHOS2 = CType(unaFila.Item(22), String)
                    a.LEVADURAS = CType(unaFila.Item(23), Integer)
                    a.LEVADURAS2 = CType(unaFila.Item(24), String)
                    a.CT = CType(unaFila.Item(25), Integer)
                    a.CT2 = CType(unaFila.Item(26), String)
                    a.CF = CType(unaFila.Item(27), Integer)
                    a.CF2 = CType(unaFila.Item(28), String)
                    a.PSEUDOMONASPP = CType(unaFila.Item(29), Integer)
                    a.PSEUDOMONASPP2 = CType(unaFila.Item(30), String)
                    a.OPERADOR = CType(unaFila.Item(31), Integer)
                    a.MARCA = CType(unaFila.Item(32), Integer)
                    Lista.Add(a)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarporsolicitud2(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, ficha, fechasolicitud, fechaproceso, muestra, detallemuestra, observaciones, estadomuestra, listambiental, listambiental2, listmono, listeriaspp, listeriaspp2, estafcoagpositivo, estafcoagpositivo2, salmonella, enterobacterias, enterobacterias2, ecoli, ecoli2, rb, mohos, mohos2, levaduras, levaduras2, ct, ct2, cf, cf2, pseudomonaspp, pseudomonaspp2, operador, marca FROM ambiental where marca = 1 and ficha = " & texto & "")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(Sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim a As New dAmbiental
                    a.ID = CType(unaFila.Item(0), Long)
                    a.FICHA = CType(unaFila.Item(1), Long)
                    a.FECHASOLICITUD = CType(unaFila.Item(2), String)
                    a.FECHAPROCESO = CType(unaFila.Item(3), String)
                    a.IDMUESTRA = CType(unaFila.Item(4), String)
                    a.DETALLEMUESTRA = CType(unaFila.Item(5), String)
                    a.OBSERVACIONES = CType(unaFila.Item(6), String)
                    a.ESTADOMUESTRA = CType(unaFila.Item(7), String)
                    a.LISTERIAAMBIENTAL = CType(unaFila.Item(8), Integer)
                    a.LISTERIAAMBIENTAL2 = CType(unaFila.Item(9), String)
                    a.LISTERIAMONOCITOGENES = CType(unaFila.Item(10), Integer)
                    a.LISTERIASPP = CType(unaFila.Item(11), Integer)
                    a.LISTERIASPP2 = CType(unaFila.Item(12), String)
                    a.ESTAFCOAGPOSITIVO = CType(unaFila.Item(13), Integer)
                    a.ESTAFCOAGPOSITIVO2 = CType(unaFila.Item(14), String)
                    a.SALMONELLA = CType(unaFila.Item(15), Integer)
                    a.ENTEROBACTERIAS = CType(unaFila.Item(16), Integer)
                    a.ENTEROBACTERIAS2 = CType(unaFila.Item(17), String)
                    a.ECOLI = CType(unaFila.Item(18), Integer)
                    a.ECOLI2 = CType(unaFila.Item(19), String)
                    a.RB = CType(unaFila.Item(20), String)
                    a.MOHOS = CType(unaFila.Item(21), Integer)
                    a.MOHOS2 = CType(unaFila.Item(22), String)
                    a.LEVADURAS = CType(unaFila.Item(23), Integer)
                    a.LEVADURAS2 = CType(unaFila.Item(24), String)
                    a.CT = CType(unaFila.Item(25), Integer)
                    a.CT2 = CType(unaFila.Item(26), String)
                    a.CF = CType(unaFila.Item(27), Integer)
                    a.CF2 = CType(unaFila.Item(28), String)
                    a.PSEUDOMONASPP = CType(unaFila.Item(29), Integer)
                    a.PSEUDOMONASPP2 = CType(unaFila.Item(30), String)
                    a.OPERADOR = CType(unaFila.Item(31), Integer)
                    a.MARCA = CType(unaFila.Item(32), Integer)
                    Lista.Add(a)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarporfecha(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim sql As String = ("SELECT id, ficha, fechasolicitud, fechaproceso, muestra, detallemuestra, observaciones, estadomuestra, listambiental, listambiental2, listmono, listeriaspp, listeriaspp2, estafcoagpositivo, estafcoagpositivo2, salmonella, enterobacterias, enterobacterias2, ecoli, ecoli2, rb, mohos, mohos2, levaduras, levaduras2, ct, ct2, cf, cf2, pseudomonaspp, pseudomonaspp2, operador, marca FROM ambiental where fechaingreso BETWEEN '" & fechadesde & "' And '" & fechahasta & "'")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim a As New dAmbiental
                    a.ID = CType(unaFila.Item(0), Long)
                    a.FICHA = CType(unaFila.Item(1), Long)
                    a.FECHASOLICITUD = CType(unaFila.Item(2), String)
                    a.FECHAPROCESO = CType(unaFila.Item(3), String)
                    a.IDMUESTRA = CType(unaFila.Item(4), String)
                    a.DETALLEMUESTRA = CType(unaFila.Item(5), String)
                    a.OBSERVACIONES = CType(unaFila.Item(6), String)
                    a.ESTADOMUESTRA = CType(unaFila.Item(7), String)
                    a.LISTERIAAMBIENTAL = CType(unaFila.Item(8), Integer)
                    a.LISTERIAAMBIENTAL2 = CType(unaFila.Item(9), String)
                    a.LISTERIAMONOCITOGENES = CType(unaFila.Item(10), Integer)
                    a.LISTERIASPP = CType(unaFila.Item(11), Integer)
                    a.LISTERIASPP2 = CType(unaFila.Item(12), String)
                    a.ESTAFCOAGPOSITIVO = CType(unaFila.Item(13), Integer)
                    a.ESTAFCOAGPOSITIVO2 = CType(unaFila.Item(14), String)
                    a.SALMONELLA = CType(unaFila.Item(15), Integer)
                    a.ENTEROBACTERIAS = CType(unaFila.Item(16), Integer)
                    a.ENTEROBACTERIAS2 = CType(unaFila.Item(17), String)
                    a.ECOLI = CType(unaFila.Item(18), Integer)
                    a.ECOLI2 = CType(unaFila.Item(19), String)
                    a.RB = CType(unaFila.Item(20), String)
                    a.MOHOS = CType(unaFila.Item(21), Integer)
                    a.MOHOS2 = CType(unaFila.Item(22), String)
                    a.LEVADURAS = CType(unaFila.Item(23), Integer)
                    a.LEVADURAS2 = CType(unaFila.Item(24), String)
                    a.CT = CType(unaFila.Item(25), Integer)
                    a.CT2 = CType(unaFila.Item(26), String)
                    a.CF = CType(unaFila.Item(27), Integer)
                    a.CF2 = CType(unaFila.Item(28), String)
                    a.PSEUDOMONASPP = CType(unaFila.Item(29), Integer)
                    a.PSEUDOMONASPP2 = CType(unaFila.Item(30), String)
                    a.OPERADOR = CType(unaFila.Item(31), Integer)
                    a.MARCA = CType(unaFila.Item(32), Integer)
                    Lista.Add(a)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
