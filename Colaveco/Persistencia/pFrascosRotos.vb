Public Class pFrascosRotos
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dFrascosRotos = CType(o, dFrascosRotos)
        Dim sql As String = "INSERT INTO frascosrotos (id, fecha, cantidad) VALUES (" & obj.ID & ", '" & obj.FECHA & "', " & obj.CANTIDAD & ")"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'frascos_rotos', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dFrascosRotos = CType(o, dFrascosRotos)
        Dim sql As String = "UPDATE frascosrotos SET fecha = '" & obj.FECHA & "', cantidad = " & obj.CANTIDAD & " WHERE id = " & obj.ID

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'frascos_rotos', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dFrascosRotos = CType(o, dFrascosRotos)
        Dim sql As String = "DELETE FROM frascosrotos WHERE id = " & obj.ID

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'frascos_rotos', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dFrascosRotos
        Dim obj As dFrascosRotos = CType(o, dFrascosRotos)
        Dim f As New dFrascosRotos
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, fecha, cantidad FROM frascosrotos WHERE id = " & obj.ID)

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                f.ID = CType(unaFila.Item(0), Long)
                f.FECHA = CType(unaFila.Item(1), String)
                f.CANTIDAD = CType(unaFila.Item(2), Integer)
                Return f
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, fecha, cantidad FROM frascosrotos order by fecha desc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim f As New dFrascosRotos
                    f.ID = CType(unaFila.Item(0), Long)
                    f.FECHA = CType(unaFila.Item(1), String)
                    f.CANTIDAD = CType(unaFila.Item(2), Integer)
                    Lista.Add(f)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarporfecha(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim sql As String = "SELECT id, fecha, cantidad FROM frascosrotos WHERE fecha >= '" & desde & "' and fecha <= '" & hasta & "' order by fecha desc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim f As New dFrascosRotos
                    f.ID = CType(unaFila.Item(0), Long)
                    f.FECHA = CType(unaFila.Item(1), String)
                    f.CANTIDAD = CType(unaFila.Item(2), Integer)
                    Lista.Add(f)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarfrascospormes(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim sql As String = "SELECT YEAR(fecha) AS AÑO, MONTH(fecha) AS MES, SUM(cantidad) as total FROM frascosrotos WHERE fecha>= '" & desde & "' and fecha<= '" & hasta & "' GROUP BY AÑO DESC, MES DESC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim infr As New dInformeFrascosRotos
                    infr.AÑO = CType(unaFila.Item(0), String)
                    infr.MES = CType(unaFila.Item(1), String)
                    infr.TOTAL = CType(unaFila.Item(2), Long)
                    Lista.Add(infr)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
