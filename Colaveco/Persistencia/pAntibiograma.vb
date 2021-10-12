Public Class pAntibiograma
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dAntibiograma = CType(o, dAntibiograma)
        Dim sql As String = "INSERT INTO antibiograma (id, ficha, fechasolicitud, fechaproceso, idanimal, tratado, tratamiento, idmicroorgaislado24, idmicroorgaislado48, rc, idtipo, combo, p, cf, ox, sxt, amc, ra, e, t, eno, gm, am, operador, marca) VALUES (" & obj.ID & ", " & obj.ficha & ",'" & obj.FECHASOLICITUD & "','" & obj.FECHAPROCESO & "','" & obj.IDANIMAL & "', " & obj.TRATADO & ", " & obj.TRATAMIENTO & "," & obj.IDMICROORGAISLADO24 & "," & obj.IDMICROORGAISLADO48 & "," & obj.RC & "," & obj.IDTIPO & "," & obj.COMBO & "," & obj.P & "," & obj.CF & ", " & obj.OX & ", " & obj.SXT & ", " & obj.AMC & ", " & obj.RA & "," & obj.E & ", " & obj.T & ", " & obj.ENO & ", " & obj.GM & ", " & obj.AM & "," & obj.OPERADOR & ", " & obj.MARCA & ")"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'antibiograma', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dAntibiograma = CType(o, dAntibiograma)
        Dim sql As String = "UPDATE antibiograma SET ficha = " & obj.ficha & ",  fechasolicitud ='" & obj.FECHASOLICITUD & "',fechaproceso ='" & obj.FECHAPROCESO & "', idanimal ='" & obj.IDANIMAL & "',tratado =" & obj.TRATADO & ",tratamiento =" & obj.TRATAMIENTO & ",idmicroorgaislado24 =" & obj.IDMICROORGAISLADO24 & ",idmicroorgaislado48 =" & obj.IDMICROORGAISLADO48 & ",rc =" & obj.RC & ",idtipo =" & obj.IDTIPO & ",combo =" & obj.COMBO & ", p ='" & obj.P & "', cf=" & obj.CF & ", ox=" & obj.OX & ", sxt=" & obj.SXT & ", amc=" & obj.AMC & ", ra=" & obj.RA & ", e=" & obj.E & ", t=" & obj.T & ", eno=" & obj.ENO & ",gm=" & obj.GM & ",am=" & obj.AM & ",operador=" & obj.OPERADOR & ", marca=" & obj.MARCA & " WHERE ID = " & obj.ID

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'antibiograma', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function desmarcarficha(ByVal o As Object) As Boolean
        Dim obj As dAntibiograma = CType(o, dAntibiograma)
        Dim sql As String = "UPDATE antibiograma SET marca = 0 WHERE ficha = " & obj.FICHA & ""

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dAntibiograma = CType(o, dAntibiograma)
        Dim sql As String = "DELETE FROM antibiograma WHERE ficha = " & obj.ficha & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'antibiograma', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dAntibiograma
        Dim obj As dAntibiograma = CType(o, dAntibiograma)
        Dim a As New dAntibiograma
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, ficha, fechasolicitud, fechaproceso, idanimal, idmicroorgaislado24, idmicroorgaislado48, rc, idtipo, combo, p, cf, ox, sxt, amc, ra, e, t, eno, gm, am, operador, marca FROM antibiograma WHERE id = " & obj.ID)

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                a.ID = CType(unaFila.Item(0), Long)
                a.ficha = CType(unaFila.Item(1), Long)
                a.FECHASOLICITUD = CType(unaFila.Item(2), String)
                a.FECHAPROCESO = CType(unaFila.Item(3), String)
                a.IDANIMAL = CType(unaFila.Item(4), String)
                a.TRATADO = CType(unaFila.Item(5), Integer)
                a.TRATAMIENTO = CType(unaFila.Item(6), Integer)
                a.IDMICROORGAISLADO24 = CType(unaFila.Item(7), Integer)
                a.IDMICROORGAISLADO48 = CType(unaFila.Item(8), Integer)
                a.RC = CType(unaFila.Item(9), Integer)
                a.IDTIPO = CType(unaFila.Item(10), Integer)
                a.COMBO = CType(unaFila.Item(11), Integer)
                a.P = CType(unaFila.Item(12), Integer)
                a.CF = CType(unaFila.Item(13), Integer)
                a.OX = CType(unaFila.Item(14), Integer)
                a.SXT = CType(unaFila.Item(15), Integer)
                a.AMC = CType(unaFila.Item(16), Integer)
                a.RA = CType(unaFila.Item(17), Integer)
                a.E = CType(unaFila.Item(18), Long)
                a.T = CType(unaFila.Item(19), Integer)
                a.ENO = CType(unaFila.Item(20), Integer)
                a.GM = CType(unaFila.Item(21), Integer)
                a.AM = CType(unaFila.Item(22), Integer)
                a.OPERADOR = CType(unaFila.Item(23), Integer)
                a.MARCA = CType(unaFila.Item(24), Integer)
                Return a
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, ficha, fechasolicitud, fechaproceso, idanimal, tratado, tratamiento, idmicroorgaislado24, idmicroorgaislado48, rc, idtipo, combo, p, cf, ox, sxt, amc, ra, e, t, eno,gm, am, operador, marca FROM antibiograma WHERE marca = 0 order by id desc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim a As New dAntibiograma
                    a.ID = CType(unaFila.Item(0), Long)
                    a.ficha = CType(unaFila.Item(1), Long)
                    a.FECHASOLICITUD = CType(unaFila.Item(2), String)
                    a.FECHAPROCESO = CType(unaFila.Item(3), String)
                    a.IDANIMAL = CType(unaFila.Item(4), String)
                    a.TRATADO = CType(unaFila.Item(5), Integer)
                    a.TRATAMIENTO = CType(unaFila.Item(6), Integer)
                    a.IDMICROORGAISLADO24 = CType(unaFila.Item(7), Integer)
                    a.IDMICROORGAISLADO48 = CType(unaFila.Item(8), Integer)
                    a.RC = CType(unaFila.Item(9), Integer)
                    a.IDTIPO = CType(unaFila.Item(10), Integer)
                    a.COMBO = CType(unaFila.Item(11), Integer)
                    a.P = CType(unaFila.Item(12), Integer)
                    a.CF = CType(unaFila.Item(13), Integer)
                    a.OX = CType(unaFila.Item(14), Integer)
                    a.SXT = CType(unaFila.Item(15), Integer)
                    a.AMC = CType(unaFila.Item(16), Integer)
                    a.RA = CType(unaFila.Item(17), Integer)
                    a.E = CType(unaFila.Item(18), Long)
                    a.T = CType(unaFila.Item(19), Integer)
                    a.ENO = CType(unaFila.Item(20), Integer)
                    a.GM = CType(unaFila.Item(21), Integer)
                    a.AM = CType(unaFila.Item(22), Integer)
                    a.OPERADOR = CType(unaFila.Item(23), Integer)
                    a.MARCA = CType(unaFila.Item(24), Integer)
                    Lista.Add(a)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
   
    
    Public Function listarfichas() As ArrayList
        Dim sql As String = "SELECT DISTINCT ficha FROM antibiograma WHERE marca = 0 order by ficha asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim a As New dAntibiograma
                    a.ficha = CType(unaFila.Item(0), Long)
                    Lista.Add(a)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarcaravanas(ByVal texto As Long) As ArrayList
        Dim sql As String = "SELECT DISTINCT idanimal FROM antibiograma WHERE ficha = '" & texto & "'"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim a As New dAntibiograma
                    a.IDANIMAL = CType(unaFila.Item(0), String)
                    Lista.Add(a)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function listarporid(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, ficha, fechasolicitud, fechaproceso, idanimal, idmicroorgaislado24, idmicroorgaislado48, rc, idtipo, combo, p, cf, ox, sxt, amc, ra, e, t,eno,gm,am, operador, marca FROM antibiograma where id = " & texto)
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim a As New dAntibiograma
                    a.ID = CType(unaFila.Item(0), Long)
                    a.ficha = CType(unaFila.Item(1), Long)
                    a.FECHASOLICITUD = CType(unaFila.Item(2), String)
                    a.FECHAPROCESO = CType(unaFila.Item(3), String)
                    a.IDANIMAL = CType(unaFila.Item(4), String)
                    a.TRATADO = CType(unaFila.Item(5), Integer)
                    a.TRATAMIENTO = CType(unaFila.Item(6), Integer)
                    a.IDMICROORGAISLADO24 = CType(unaFila.Item(7), Integer)
                    a.IDMICROORGAISLADO48 = CType(unaFila.Item(8), Integer)
                    a.RC = CType(unaFila.Item(9), Integer)
                    a.IDTIPO = CType(unaFila.Item(10), Integer)
                    a.COMBO = CType(unaFila.Item(11), Integer)
                    a.P = CType(unaFila.Item(12), Integer)
                    a.CF = CType(unaFila.Item(13), Integer)
                    a.OX = CType(unaFila.Item(14), Integer)
                    a.SXT = CType(unaFila.Item(15), Integer)
                    a.AMC = CType(unaFila.Item(16), Integer)
                    a.RA = CType(unaFila.Item(17), Integer)
                    a.E = CType(unaFila.Item(18), Long)
                    a.T = CType(unaFila.Item(19), Integer)
                    a.ENO = CType(unaFila.Item(20), Integer)
                    a.GM = CType(unaFila.Item(21), Integer)
                    a.AM = CType(unaFila.Item(22), Integer)
                    a.OPERADOR = CType(unaFila.Item(23), Integer)
                    a.MARCA = CType(unaFila.Item(24), Integer)
                    Lista.Add(a)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarpormuestra(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, ficha, fechasolicitud, fechaproceso, idanimal, tratado, tratamiento,idmicroorgaislado24, idmicroorgaislado48, rc, idtipo, combo, p, cf, ox, sxt, amc, ra, e, t,eno,gm,am, operador, marca FROM antibiograma where ficha = " & texto & " order by idanimal asc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim a As New dAntibiograma
                    a.ID = CType(unaFila.Item(0), Long)
                    a.ficha = CType(unaFila.Item(1), Long)
                    a.FECHASOLICITUD = CType(unaFila.Item(2), String)
                    a.FECHAPROCESO = CType(unaFila.Item(3), String)
                    a.IDANIMAL = CType(unaFila.Item(4), String)
                    a.TRATADO = CType(unaFila.Item(5), Integer)
                    a.TRATAMIENTO = CType(unaFila.Item(6), Integer)
                    a.IDMICROORGAISLADO24 = CType(unaFila.Item(7), Integer)
                    a.IDMICROORGAISLADO48 = CType(unaFila.Item(8), Integer)
                    a.RC = CType(unaFila.Item(9), Integer)
                    a.IDTIPO = CType(unaFila.Item(10), Integer)
                    a.COMBO = CType(unaFila.Item(11), Integer)
                    a.P = CType(unaFila.Item(12), Integer)
                    a.CF = CType(unaFila.Item(13), Integer)
                    a.OX = CType(unaFila.Item(14), Integer)
                    a.SXT = CType(unaFila.Item(15), Integer)
                    a.AMC = CType(unaFila.Item(16), Integer)
                    a.RA = CType(unaFila.Item(17), Integer)
                    a.E = CType(unaFila.Item(18), Long)
                    a.T = CType(unaFila.Item(19), Integer)
                    a.ENO = CType(unaFila.Item(20), Integer)
                    a.GM = CType(unaFila.Item(21), Integer)
                    a.AM = CType(unaFila.Item(22), Integer)
                    a.OPERADOR = CType(unaFila.Item(23), Integer)
                    a.MARCA = CType(unaFila.Item(24), Integer)
                    Lista.Add(a)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    
    Public Function listarporsolicitud(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, ficha, fechasolicitud, fechaproceso, idanimal, tratado, tratamiento,idmicroorgaislado24, idmicroorgaislado48, rc, idtipo, combo, p, cf, ox, sxt, amc, ra, e, t,eno,gm,am, operador, marca FROM antibiograma where marca = 0 and ficha = " & texto & "")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim a As New dAntibiograma
                    a.ID = CType(unaFila.Item(0), Long)
                    a.ficha = CType(unaFila.Item(1), Long)
                    a.FECHASOLICITUD = CType(unaFila.Item(2), String)
                    a.FECHAPROCESO = CType(unaFila.Item(3), String)
                    a.IDANIMAL = CType(unaFila.Item(4), String)
                    a.TRATADO = CType(unaFila.Item(5), Integer)
                    a.TRATAMIENTO = CType(unaFila.Item(6), Integer)
                    a.IDMICROORGAISLADO24 = CType(unaFila.Item(7), Integer)
                    a.IDMICROORGAISLADO48 = CType(unaFila.Item(8), Integer)
                    a.RC = CType(unaFila.Item(9), Integer)
                    a.IDTIPO = CType(unaFila.Item(10), Integer)
                    a.COMBO = CType(unaFila.Item(11), Integer)
                    a.P = CType(unaFila.Item(12), Integer)
                    a.CF = CType(unaFila.Item(13), Integer)
                    a.OX = CType(unaFila.Item(14), Integer)
                    a.SXT = CType(unaFila.Item(15), Integer)
                    a.AMC = CType(unaFila.Item(16), Integer)
                    a.RA = CType(unaFila.Item(17), Integer)
                    a.E = CType(unaFila.Item(18), Long)
                    a.T = CType(unaFila.Item(19), Integer)
                    a.ENO = CType(unaFila.Item(20), Integer)
                    a.GM = CType(unaFila.Item(21), Integer)
                    a.AM = CType(unaFila.Item(22), Integer)
                    a.OPERADOR = CType(unaFila.Item(23), Integer)
                    a.MARCA = CType(unaFila.Item(24), Integer)
                    Lista.Add(a)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    
    Public Function listarporsolicitud2(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, ficha, fechasolicitud, fechaproceso, idanimal, tratado, tratamiento,idmicroorgaislado24, idmicroorgaislado48, rc, idtipo, combo, p, cf, ox, sxt, amc, ra, e, t,eno,gm,am, operador, marca FROM antibiograma where marca = 1 and ficha = " & texto & " ORDER by combo asc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim a As New dAntibiograma
                    a.ID = CType(unaFila.Item(0), Long)
                    a.ficha = CType(unaFila.Item(1), Long)
                    a.FECHASOLICITUD = CType(unaFila.Item(2), String)
                    a.FECHAPROCESO = CType(unaFila.Item(3), String)
                    a.IDANIMAL = CType(unaFila.Item(4), String)
                    a.TRATADO = CType(unaFila.Item(5), Integer)
                    a.TRATAMIENTO = CType(unaFila.Item(6), Integer)
                    a.IDMICROORGAISLADO24 = CType(unaFila.Item(7), Integer)
                    a.IDMICROORGAISLADO48 = CType(unaFila.Item(8), Integer)
                    a.RC = CType(unaFila.Item(9), Integer)
                    a.IDTIPO = CType(unaFila.Item(10), Integer)
                    a.COMBO = CType(unaFila.Item(11), Integer)
                    a.P = CType(unaFila.Item(12), Integer)
                    a.CF = CType(unaFila.Item(13), Integer)
                    a.OX = CType(unaFila.Item(14), Integer)
                    a.SXT = CType(unaFila.Item(15), Integer)
                    a.AMC = CType(unaFila.Item(16), Integer)
                    a.RA = CType(unaFila.Item(17), Integer)
                    a.E = CType(unaFila.Item(18), Long)
                    a.T = CType(unaFila.Item(19), Integer)
                    a.ENO = CType(unaFila.Item(20), Integer)
                    a.GM = CType(unaFila.Item(21), Integer)
                    a.AM = CType(unaFila.Item(22), Integer)
                    a.OPERADOR = CType(unaFila.Item(23), Integer)
                    a.MARCA = CType(unaFila.Item(24), Integer)
                    Lista.Add(a)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarporsolicitud3(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, ficha, fechasolicitud, fechaproceso, DISTINCT idanimal, tratado, tratamiento,idmicroorgaislado24, idmicroorgaislado48, rc, idtipo, combo, p, cf, ox, sxt, amc, ra, e, t,eno,gm,am, operador, marca FROM antibiograma where marca = 1 and ficha = " & texto & " ORDER by combo asc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim a As New dAntibiograma
                    a.ID = CType(unaFila.Item(0), Long)
                    a.ficha = CType(unaFila.Item(1), Long)
                    a.FECHASOLICITUD = CType(unaFila.Item(2), String)
                    a.FECHAPROCESO = CType(unaFila.Item(3), String)
                    a.IDANIMAL = CType(unaFila.Item(4), String)
                    a.TRATADO = CType(unaFila.Item(5), Integer)
                    a.TRATAMIENTO = CType(unaFila.Item(6), Integer)
                    a.IDMICROORGAISLADO24 = CType(unaFila.Item(7), Integer)
                    a.IDMICROORGAISLADO48 = CType(unaFila.Item(8), Integer)
                    a.RC = CType(unaFila.Item(9), Integer)
                    a.IDTIPO = CType(unaFila.Item(10), Integer)
                    a.COMBO = CType(unaFila.Item(11), Integer)
                    a.P = CType(unaFila.Item(12), Integer)
                    a.CF = CType(unaFila.Item(13), Integer)
                    a.OX = CType(unaFila.Item(14), Integer)
                    a.SXT = CType(unaFila.Item(15), Integer)
                    a.AMC = CType(unaFila.Item(16), Integer)
                    a.RA = CType(unaFila.Item(17), Integer)
                    a.E = CType(unaFila.Item(18), Long)
                    a.T = CType(unaFila.Item(19), Integer)
                    a.ENO = CType(unaFila.Item(20), Integer)
                    a.GM = CType(unaFila.Item(21), Integer)
                    a.AM = CType(unaFila.Item(22), Integer)
                    a.OPERADOR = CType(unaFila.Item(23), Integer)
                    a.MARCA = CType(unaFila.Item(24), Integer)
                    Lista.Add(a)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarporfecha(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim sql As String = ("SELECT id, ficha, fechasolicitud, fechaproceso, idanimal, tratado, tratamiento, idmicroorgaislado24, idmicroorgaislado48, rc, idtipo, combo, p, cf, ox, sxt, amc, ra, e, t, eno,gm,am,operador, marca FROM antibiograma where fechasolicitud BETWEEN '" & fechadesde & "' And '" & fechahasta & "' AND marca=1")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim a As New dAntibiograma
                    a.ID = CType(unaFila.Item(0), Long)
                    a.ficha = CType(unaFila.Item(1), Long)
                    a.FECHASOLICITUD = CType(unaFila.Item(2), String)
                    a.FECHAPROCESO = CType(unaFila.Item(3), String)
                    a.IDANIMAL = CType(unaFila.Item(4), String)
                    a.TRATADO = CType(unaFila.Item(5), Integer)
                    a.TRATAMIENTO = CType(unaFila.Item(6), Integer)
                    a.IDMICROORGAISLADO24 = CType(unaFila.Item(7), Integer)
                    a.IDMICROORGAISLADO48 = CType(unaFila.Item(8), Integer)
                    a.RC = CType(unaFila.Item(9), Integer)
                    a.IDTIPO = CType(unaFila.Item(10), Integer)
                    a.COMBO = CType(unaFila.Item(11), Integer)
                    a.P = CType(unaFila.Item(12), Integer)
                    a.CF = CType(unaFila.Item(13), Integer)
                    a.OX = CType(unaFila.Item(14), Integer)
                    a.SXT = CType(unaFila.Item(15), Integer)
                    a.AMC = CType(unaFila.Item(16), Integer)
                    a.RA = CType(unaFila.Item(17), Integer)
                    a.E = CType(unaFila.Item(18), Long)
                    a.T = CType(unaFila.Item(19), Integer)
                    a.ENO = CType(unaFila.Item(20), Integer)
                    a.GM = CType(unaFila.Item(21), Integer)
                    a.AM = CType(unaFila.Item(22), Integer)
                    a.OPERADOR = CType(unaFila.Item(23), Integer)
                    a.MARCA = CType(unaFila.Item(24), Integer)
                    Lista.Add(a)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxidanimal(ByVal idsol As Long, ByVal idanimal As String) As ArrayList
        Dim sql As String = ("SELECT id, ficha, fechasolicitud, fechaproceso, idanimal, tratado, tratamiento,idmicroorgaislado24, idmicroorgaislado48, rc, idtipo, combo, p, cf, ox, sxt, amc, ra, e, t, eno,gm,am,operador, marca FROM antibiograma where ficha = " & idsol & " And idanimal = '" & idanimal & "'")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim a As New dAntibiograma
                    a.ID = CType(unaFila.Item(0), Long)
                    a.ficha = CType(unaFila.Item(1), Long)
                    a.FECHASOLICITUD = CType(unaFila.Item(2), String)
                    a.FECHAPROCESO = CType(unaFila.Item(3), String)
                    a.IDANIMAL = CType(unaFila.Item(4), String)
                    a.TRATADO = CType(unaFila.Item(5), Integer)
                    a.TRATAMIENTO = CType(unaFila.Item(6), Integer)
                    a.IDMICROORGAISLADO24 = CType(unaFila.Item(7), Integer)
                    a.IDMICROORGAISLADO48 = CType(unaFila.Item(8), Integer)
                    a.RC = CType(unaFila.Item(9), Integer)
                    a.IDTIPO = CType(unaFila.Item(10), Integer)
                    a.COMBO = CType(unaFila.Item(11), Integer)
                    a.P = CType(unaFila.Item(12), Integer)
                    a.CF = CType(unaFila.Item(13), Integer)
                    a.OX = CType(unaFila.Item(14), Integer)
                    a.SXT = CType(unaFila.Item(15), Integer)
                    a.AMC = CType(unaFila.Item(16), Integer)
                    a.RA = CType(unaFila.Item(17), Integer)
                    a.E = CType(unaFila.Item(18), Long)
                    a.T = CType(unaFila.Item(19), Integer)
                    a.ENO = CType(unaFila.Item(20), Integer)
                    a.GM = CType(unaFila.Item(21), Integer)
                    a.AM = CType(unaFila.Item(22), Integer)
                    a.OPERADOR = CType(unaFila.Item(23), Integer)
                    a.MARCA = CType(unaFila.Item(24), Integer)
                    Lista.Add(a)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listaraislamientos(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT DISTINCT idanimal FROM antibiograma where ficha = " & texto & " order by idanimal asc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim a As New dAntibiograma
                    a.IDANIMAL = CType(unaFila.Item(0), String)
                    Lista.Add(a)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar_muestras(ByVal idATB As Long) As ArrayList
        Dim sql As String = "SELECT DISTINCT idanimal FROM antibiograma WHERE ficha = " & idATB & ""
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dAntibiograma
                    l.IDANIMAL = CType(unaFila.Item(0), String)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar_fichas(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim sql As String = "SELECT DISTINCT ficha FROM antibiograma WHERE fechasolicitud >= '" & desde & "' AND fechasolicitud <='" & hasta & "'"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dAntibiograma
                    l.ficha = CType(unaFila.Item(0), Long)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxfecha(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim sql As String = ("SELECT id, ficha, fechasolicitud, fechaproceso, idanimal, tratado, tratamiento,idmicroorgaislado24, idmicroorgaislado48, rc, idtipo, combo, p, cf, ox, sxt, amc, ra, e, t,eno,gm,am, operador, marca FROM antibiograma where fechasolicitud BETWEEN '" & desde & "' And '" & hasta & "'")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim a As New dAntibiograma
                    a.ID = CType(unaFila.Item(0), Long)
                    a.ficha = CType(unaFila.Item(1), Long)
                    a.FECHASOLICITUD = CType(unaFila.Item(2), String)
                    a.FECHAPROCESO = CType(unaFila.Item(3), String)
                    a.IDANIMAL = CType(unaFila.Item(4), String)
                    a.TRATADO = CType(unaFila.Item(5), Integer)
                    a.TRATAMIENTO = CType(unaFila.Item(6), Integer)
                    a.IDMICROORGAISLADO24 = CType(unaFila.Item(7), Integer)
                    a.IDMICROORGAISLADO48 = CType(unaFila.Item(8), Integer)
                    a.RC = CType(unaFila.Item(9), Integer)
                    a.IDTIPO = CType(unaFila.Item(10), Integer)
                    a.COMBO = CType(unaFila.Item(11), Integer)
                    a.P = CType(unaFila.Item(12), Integer)
                    a.CF = CType(unaFila.Item(13), Integer)
                    a.OX = CType(unaFila.Item(14), Integer)
                    a.SXT = CType(unaFila.Item(15), Integer)
                    a.AMC = CType(unaFila.Item(16), Integer)
                    a.RA = CType(unaFila.Item(17), Integer)
                    a.E = CType(unaFila.Item(18), Long)
                    a.T = CType(unaFila.Item(19), Integer)
                    a.ENO = CType(unaFila.Item(20), Integer)
                    a.GM = CType(unaFila.Item(21), Integer)
                    a.AM = CType(unaFila.Item(22), Integer)
                    a.OPERADOR = CType(unaFila.Item(23), Integer)
                    a.MARCA = CType(unaFila.Item(24), Integer)
                    Lista.Add(a)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
