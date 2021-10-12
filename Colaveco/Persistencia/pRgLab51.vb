Public Class pRgLab51
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dRgLab51 = CType(o, dRgLab51)
        Dim sql As String = "INSERT INTO rglab51 (id, fecha, equipo, operador, muestra, resultado) VALUES (" & obj.ID & ", '" & obj.FECHA & "','" & obj.EQUIPO & "'," & obj.OPERADOR & "," & obj.MUESTRA & "," & obj.RESULTADO & ")"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'rglab51', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dRgLab51 = CType(o, dRgLab51)
        Dim sql As String = "UPDATE rglab51 SET fecha ='" & obj.FECHA & "',equipo ='" & obj.EQUIPO & "', operador = " & obj.OPERADOR & ",muestra = " & obj.MUESTRA & ",resultado = " & obj.RESULTADO & " WHERE ID = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'rglab51', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dRgLab51 = CType(o, dRgLab51)
        Dim sql As String = "DELETE FROM rglab51 WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'rglab51', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function

    Public Function buscar(ByVal o As Object) As dRgLab51
        Dim obj As dRgLab51 = CType(o, dRgLab51)
        Dim c As New dRgLab51
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, fecha, equipo, operador, muestra, resultado FROM rglab51 WHERE id = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                c.ID = CType(unaFila.Item(0), Long)
                c.FECHA = CType(unaFila.Item(1), String)
                c.EQUIPO = CType(unaFila.Item(2), String)
                c.OPERADOR = CType(unaFila.Item(3), Integer)
                c.MUESTRA = CType(unaFila.Item(4), Integer)
                c.RESULTADO = CType(unaFila.Item(5), Double)
                Return c
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, fecha, equipo, operador, muestra, resultado FROM rglab51 order by fecha desc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dRgLab51
                    c.ID = CType(unaFila.Item(0), Long)
                    c.FECHA = CType(unaFila.Item(1), String)
                    c.EQUIPO = CType(unaFila.Item(2), String)
                    c.OPERADOR = CType(unaFila.Item(3), Integer)
                    c.MUESTRA = CType(unaFila.Item(4), Integer)
                    c.RESULTADO = CType(unaFila.Item(5), Double)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarfechas() As ArrayList
        Dim sql As String = "SELECT DISTINCT fecha FROM rglab51 order by fecha desc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim rg51 As New dRgLab51
                    rg51.FECHA = CType(unaFila.Item(0), String)
                    Lista.Add(rg51)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxfechaxequipo(ByVal fecha As String, ByVal equipo As String) As ArrayList
        Dim sql As String = "SELECT id, fecha, equipo, operador, muestra, resultado FROM rglab51 WHERE fecha = '" & fecha & "' AND equipo = '" & equipo & "'order by id asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dRgLab51
                    c.ID = CType(unaFila.Item(0), Long)
                    c.FECHA = CType(unaFila.Item(1), String)
                    c.EQUIPO = CType(unaFila.Item(2), String)
                    c.OPERADOR = CType(unaFila.Item(3), Integer)
                    c.MUESTRA = CType(unaFila.Item(4), Integer)
                    c.RESULTADO = CType(unaFila.Item(5), Double)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscarultimobentley(ByVal o As Object) As dRgLab51
        Dim obj As dRgLab51 = CType(o, dRgLab51)
        Dim c As New dRgLab51
        Dim equipo As String = "Bentley"
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT fecha FROM rglab51 where equipo= '" & equipo & "' AND fecha = (SELECT MAX(fecha) FROM rglab51)")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                c.FECHA = CType(unaFila.Item(0), String)
                Return c
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscarultimodelta(ByVal o As Object) As dRgLab51
        Dim obj As dRgLab51 = CType(o, dRgLab51)
        Dim c As New dRgLab51
        Dim equipo As String = "Delta"
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT fecha FROM rglab51 where equipo= '" & equipo & "' AND fecha = (SELECT MAX(fecha) FROM rglab51)")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                c.FECHA = CType(unaFila.Item(0), String)
                Return c
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
