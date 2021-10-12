Public Class pAgua3
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dAgua3 = CType(o, dAgua3)
        Dim sql As String = "INSERT INTO analisisdeagua3 (id, ficha, fechaentrada, fechaemision, idmuestra, observaciones, ca, mg, na, fe, k, al, cd, cr, cu, pb, mn, fem, zn, se, operador, marca) VALUES (" & obj.ID & ", " & obj.FICHA & ",'" & obj.FECHAENTRADA & "','" & obj.FECHAEMISION & "','" & obj.IDMUESTRA & "', '" & obj.OBSERVACIONES & "', " & obj.CA & "," & obj.MG & "," & obj.NA & "," & obj.FE & "," & obj.K & "," & obj.AL & "," & obj.CD & ", " & obj.CR & ", " & obj.CU & ", " & obj.PB & "," & obj.MN & ", " & obj.FEM & ", " & obj.ZN & ", " & obj.SE & ", " & obj.OPERADOR & ", " & obj.MARCA & ")"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'analisisdeagua3', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dAgua3 = CType(o, dAgua3)
        Dim sql As String = "UPDATE analisisdeagua3 SET ficha = " & obj.FICHA & ",  fechaentrada ='" & obj.FECHAENTRADA & "',fechaemision ='" & obj.FECHAEMISION & "', idmuestra ='" & obj.IDMUESTRA & "',observaciones ='" & obj.OBSERVACIONES & "', ca= " & obj.CA & ", mg= " & obj.MG & ", na= " & obj.NA & ", fe= " & obj.FE & ", k= " & obj.K & ", al= " & obj.AL & ", cd= " & obj.CD & ", cr= " & obj.CR & ", cu= " & obj.CU & ", pb= " & obj.PB & ", mn= " & obj.MN & ", fem= " & obj.FEM & ", zn= " & obj.ZN & ", se= " & obj.SE & ", operador=" & obj.OPERADOR & ", marca=" & obj.MARCA & " WHERE ID = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'analisisdeagua3', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar2(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dAgua3 = CType(o, dAgua3)
        Dim sql As String = "UPDATE analisisdeagua3 SET fechaemision ='" & obj.FECHAEMISION & "', marca=" & obj.MARCA & " WHERE ID = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'analisisdeagua3', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dAgua3 = CType(o, dAgua3)
        Dim sql As String = "DELETE FROM analisisdeagua3 WHERE ficha = " & obj.FICHA & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'analisisdeagua3', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dAgua3
        Dim obj As dAgua3 = CType(o, dAgua3)
        Dim a As New dAgua3
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, ficha, fechaentrada, fechaemision, idmuestra, observaciones, ca, mg, na, fe, k, al, cd, cr, cu, pb, mn, fem, zn, se, operador, marca FROM analisisdeagua3 WHERE id = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                a.ID = CType(unaFila.Item(0), Long)
                a.FICHA = CType(unaFila.Item(1), Long)
                a.FECHAENTRADA = CType(unaFila.Item(2), String)
                a.FECHAEMISION = CType(unaFila.Item(3), String)
                a.IDMUESTRA = CType(unaFila.Item(4), String)
                a.OBSERVACIONES = CType(unaFila.Item(5), String)
                a.CA = CType(unaFila.Item(6), Double)
                a.MG = CType(unaFila.Item(7), Double)
                a.NA = CType(unaFila.Item(8), Double)
                a.FE = CType(unaFila.Item(9), Double)
                a.K = CType(unaFila.Item(10), Double)
                a.AL = CType(unaFila.Item(11), Double)
                a.CD = CType(unaFila.Item(12), Double)
                a.CR = CType(unaFila.Item(13), Double)
                a.CU = CType(unaFila.Item(14), Double)
                a.PB = CType(unaFila.Item(15), Double)
                a.MN = CType(unaFila.Item(16), Double)
                a.FEM = CType(unaFila.Item(17), Double)
                a.ZN = CType(unaFila.Item(18), Double)
                a.SE = CType(unaFila.Item(19), Double)
                a.OPERADOR = CType(unaFila.Item(20), Integer)
                a.MARCA = CType(unaFila.Item(21), Integer)
                Return a
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, ficha, fechaentrada, fechaemision, idmuestra, observaciones, ca, mg, na, fe, k, al, cd, cr, cu, pb, mn, fem, zn, se, operador, marca FROM analisisdeagua3 WHERE marca = 0 order by id desc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim a As New dAgua3
                    a.ID = CType(unaFila.Item(0), Long)
                    a.FICHA = CType(unaFila.Item(1), Long)
                    a.FECHAENTRADA = CType(unaFila.Item(2), String)
                    a.FECHAEMISION = CType(unaFila.Item(3), String)
                    a.IDMUESTRA = CType(unaFila.Item(4), String)
                    a.OBSERVACIONES = CType(unaFila.Item(5), String)
                    a.CA = CType(unaFila.Item(6), Double)
                    a.MG = CType(unaFila.Item(7), Double)
                    a.NA = CType(unaFila.Item(8), Double)
                    a.FE = CType(unaFila.Item(9), Double)
                    a.K = CType(unaFila.Item(10), Double)
                    a.AL = CType(unaFila.Item(11), Double)
                    a.CD = CType(unaFila.Item(12), Double)
                    a.CR = CType(unaFila.Item(13), Double)
                    a.CU = CType(unaFila.Item(14), Double)
                    a.PB = CType(unaFila.Item(15), Double)
                    a.MN = CType(unaFila.Item(16), Double)
                    a.FEM = CType(unaFila.Item(17), Double)
                    a.ZN = CType(unaFila.Item(18), Double)
                    a.SE = CType(unaFila.Item(19), Double)
                    a.OPERADOR = CType(unaFila.Item(20), Integer)
                    a.MARCA = CType(unaFila.Item(21), Integer)
                    Lista.Add(a)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarfichas() As ArrayList
        Dim sql As String = "SELECT DISTINCT ficha FROM analisisdeagua3 WHERE marca = 0 order by ficha asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim a As New dAgua3
                    a.ficha = CType(unaFila.Item(0), Long)
                    Lista.Add(a)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function listarporid(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, ficha, fechaentrada, fechaemision, idmuestra, observaciones, ca, mg, na, fe, k, al, cd, cr, cu, pb, mn, fem, zn, se, operador, marca  FROM analisisdeagua3 where marca = 0 and ficha = " & texto & "")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim a As New dAgua3
                   a.ID = CType(unaFila.Item(0), Long)
                    a.FICHA = CType(unaFila.Item(1), Long)
                    a.FECHAENTRADA = CType(unaFila.Item(2), String)
                    a.FECHAEMISION = CType(unaFila.Item(3), String)
                    a.IDMUESTRA = CType(unaFila.Item(4), String)
                    a.OBSERVACIONES = CType(unaFila.Item(5), String)
                    a.CA = CType(unaFila.Item(6), Double)
                    a.MG = CType(unaFila.Item(7), Double)
                    a.NA = CType(unaFila.Item(8), Double)
                    a.FE = CType(unaFila.Item(9), Double)
                    a.K = CType(unaFila.Item(10), Double)
                    a.AL = CType(unaFila.Item(11), Double)
                    a.CD = CType(unaFila.Item(12), Double)
                    a.CR = CType(unaFila.Item(13), Double)
                    a.CU = CType(unaFila.Item(14), Double)
                    a.PB = CType(unaFila.Item(15), Double)
                    a.MN = CType(unaFila.Item(16), Double)
                    a.FEM = CType(unaFila.Item(17), Double)
                    a.ZN = CType(unaFila.Item(18), Double)
                    a.SE = CType(unaFila.Item(19), Double)
                    a.OPERADOR = CType(unaFila.Item(20), Integer)
                    a.MARCA = CType(unaFila.Item(21), Integer)
                    Lista.Add(a)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarporid2(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, ficha, fechaentrada, fechaemision, idmuestra, observaciones, ca, mg, na, fe, k, al, cd, cr, cu, pb, mn, fem, zn, se, operador, marca FROM analisisdeagua3 where ficha = " & texto & "")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim a As New dAgua3
                     a.ID = CType(unaFila.Item(0), Long)
                    a.FICHA = CType(unaFila.Item(1), Long)
                    a.FECHAENTRADA = CType(unaFila.Item(2), String)
                    a.FECHAEMISION = CType(unaFila.Item(3), String)
                    a.IDMUESTRA = CType(unaFila.Item(4), String)
                    a.OBSERVACIONES = CType(unaFila.Item(5), String)
                    a.CA = CType(unaFila.Item(6), Double)
                    a.MG = CType(unaFila.Item(7), Double)
                    a.NA = CType(unaFila.Item(8), Double)
                    a.FE = CType(unaFila.Item(9), Double)
                    a.K = CType(unaFila.Item(10), Double)
                    a.AL = CType(unaFila.Item(11), Double)
                    a.CD = CType(unaFila.Item(12), Double)
                    a.CR = CType(unaFila.Item(13), Double)
                    a.CU = CType(unaFila.Item(14), Double)
                    a.PB = CType(unaFila.Item(15), Double)
                    a.MN = CType(unaFila.Item(16), Double)
                    a.FEM = CType(unaFila.Item(17), Double)
                    a.ZN = CType(unaFila.Item(18), Double)
                    a.SE = CType(unaFila.Item(19), Double)
                    a.OPERADOR = CType(unaFila.Item(20), Integer)
                    a.MARCA = CType(unaFila.Item(21), Integer)
                    Lista.Add(a)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function listarporsolicitud(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, ficha, fechaentrada, fechaemision, idmuestra, observaciones, ca, mg, na, fe, k, al, cd, cr, cu, pb, mn, fem, zn, se, operador, marca FROM analisisdeagua3 where marca = 0 and ficha = " & texto & "")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim a As New dAgua3
                     a.ID = CType(unaFila.Item(0), Long)
                    a.FICHA = CType(unaFila.Item(1), Long)
                    a.FECHAENTRADA = CType(unaFila.Item(2), String)
                    a.FECHAEMISION = CType(unaFila.Item(3), String)
                    a.IDMUESTRA = CType(unaFila.Item(4), String)
                    a.OBSERVACIONES = CType(unaFila.Item(5), String)
                    a.CA = CType(unaFila.Item(6), Double)
                    a.MG = CType(unaFila.Item(7), Double)
                    a.NA = CType(unaFila.Item(8), Double)
                    a.FE = CType(unaFila.Item(9), Double)
                    a.K = CType(unaFila.Item(10), Double)
                    a.AL = CType(unaFila.Item(11), Double)
                    a.CD = CType(unaFila.Item(12), Double)
                    a.CR = CType(unaFila.Item(13), Double)
                    a.CU = CType(unaFila.Item(14), Double)
                    a.PB = CType(unaFila.Item(15), Double)
                    a.MN = CType(unaFila.Item(16), Double)
                    a.FEM = CType(unaFila.Item(17), Double)
                    a.ZN = CType(unaFila.Item(18), Double)
                    a.SE = CType(unaFila.Item(19), Double)
                    a.OPERADOR = CType(unaFila.Item(20), Integer)
                    a.MARCA = CType(unaFila.Item(21), Integer)
                    Lista.Add(a)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarporsolicitud2(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, ficha, fechaentrada, fechaemision, idmuestra, observaciones, ca, mg, na, fe, k, al, cd, cr, cu, pb, mn, fem, zn, se, operador, marca FROM analisisdeagua3 where marca = 1 and ficha = " & texto & "")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim a As New dAgua3
                     a.ID = CType(unaFila.Item(0), Long)
                    a.FICHA = CType(unaFila.Item(1), Long)
                    a.FECHAENTRADA = CType(unaFila.Item(2), String)
                    a.FECHAEMISION = CType(unaFila.Item(3), String)
                    a.IDMUESTRA = CType(unaFila.Item(4), String)
                    a.OBSERVACIONES = CType(unaFila.Item(5), String)
                    a.CA = CType(unaFila.Item(6), Double)
                    a.MG = CType(unaFila.Item(7), Double)
                    a.NA = CType(unaFila.Item(8), Double)
                    a.FE = CType(unaFila.Item(9), Double)
                    a.K = CType(unaFila.Item(10), Double)
                    a.AL = CType(unaFila.Item(11), Double)
                    a.CD = CType(unaFila.Item(12), Double)
                    a.CR = CType(unaFila.Item(13), Double)
                    a.CU = CType(unaFila.Item(14), Double)
                    a.PB = CType(unaFila.Item(15), Double)
                    a.MN = CType(unaFila.Item(16), Double)
                    a.FEM = CType(unaFila.Item(17), Double)
                    a.ZN = CType(unaFila.Item(18), Double)
                    a.SE = CType(unaFila.Item(19), Double)
                    a.OPERADOR = CType(unaFila.Item(20), Integer)
                    a.MARCA = CType(unaFila.Item(21), Integer)
                    Lista.Add(a)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarporfecha(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim sql As String = ("SELECT id, ficha, fechaentrada, fechaemision, idmuestra, observaciones, ca, mg, na, fe, k, al, cd, cr, cu, pb, mn, fem, zn, se, operador, marca FROM analisisdeagua3 where fechaingreso BETWEEN '" & fechadesde & "' And '" & fechahasta & "'")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim a As New dAgua3
                    a.ID = CType(unaFila.Item(0), Long)
                    a.FICHA = CType(unaFila.Item(1), Long)
                    a.FECHAENTRADA = CType(unaFila.Item(2), String)
                    a.FECHAEMISION = CType(unaFila.Item(3), String)
                    a.IDMUESTRA = CType(unaFila.Item(4), String)
                    a.OBSERVACIONES = CType(unaFila.Item(5), String)
                    a.CA = CType(unaFila.Item(6), Double)
                    a.MG = CType(unaFila.Item(7), Double)
                    a.NA = CType(unaFila.Item(8), Double)
                    a.FE = CType(unaFila.Item(9), Double)
                    a.K = CType(unaFila.Item(10), Double)
                    a.AL = CType(unaFila.Item(11), Double)
                    a.CD = CType(unaFila.Item(12), Double)
                    a.CR = CType(unaFila.Item(13), Double)
                    a.CU = CType(unaFila.Item(14), Double)
                    a.PB = CType(unaFila.Item(15), Double)
                    a.MN = CType(unaFila.Item(16), Double)
                    a.FEM = CType(unaFila.Item(17), Double)
                    a.ZN = CType(unaFila.Item(18), Double)
                    a.SE = CType(unaFila.Item(19), Double)
                    a.OPERADOR = CType(unaFila.Item(20), Integer)
                    a.MARCA = CType(unaFila.Item(21), Integer)
                    Lista.Add(a)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
