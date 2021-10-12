Public Class pRgLab58_informes
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dRgLab58_informes = CType(o, dRgLab58_informes)
        Dim sql As String = "INSERT INTO rglab58_informes (id, fecha, operador, muestra, resb1, resb2, promb, resd1, resd2, promd, promedio, difmax, dif, alerta, porcentaje, resultado) VALUES (" & obj.ID & ", '" & obj.FECHA & "'," & obj.OPERADOR & "," & obj.MUESTRA & "," & obj.RESB1 & "," & obj.RESB2 & "," & obj.PROMB & "," & obj.RESD1 & "," & obj.RESD2 & "," & obj.PROMD & "," & obj.PROMEDIO & "," & obj.DIFMAX & "," & obj.DIF & "," & obj.ALERTA & "," & obj.PORCENTAJE & "," & obj.RESULTADO & ")"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'rglab58_informes', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dRgLab58_informes = CType(o, dRgLab58_informes)
        Dim sql As String = "UPDATE rglab58_informes SET fecha ='" & obj.FECHA & "', operador = " & obj.OPERADOR & ",muestra = " & obj.MUESTRA & ",resb1 = " & obj.RESB1 & ",resb2 = " & obj.RESB2 & ",promb = " & obj.PROMB & ",resd1 = " & obj.RESD1 & ",resd2 = " & obj.RESD2 & ",promd = " & obj.PROMD & ",promedio = " & obj.PROMEDIO & ",difmax = " & obj.DIFMAX & ",dif = " & obj.DIF & ",alerta = " & obj.ALERTA & ",porcentaje = " & obj.PORCENTAJE & ",resultado = " & obj.RESULTADO & " WHERE ID = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'rglab58_informes', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dRgLab58_informes = CType(o, dRgLab58_informes)
        Dim sql As String = "DELETE FROM rglab58_informes WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'rglab58_informes', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function

    Public Function buscar(ByVal o As Object) As dRgLab58_informes
        Dim obj As dRgLab58_informes = CType(o, dRgLab58_informes)
        Dim c As New dRgLab58_informes
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, fecha, operador, muestra, resb1, resb2, promb, resd1, resd2, promd, promedio, difmax, dif, alerta, porcentaje, resultado FROM rglab58_informes WHERE id = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                c.ID = CType(unaFila.Item(0), Long)
                c.FECHA = CType(unaFila.Item(1), String)
                c.OPERADOR = CType(unaFila.Item(2), Integer)
                c.MUESTRA = CType(unaFila.Item(3), Integer)
                c.RESB1 = CType(unaFila.Item(4), Integer)
                c.RESB2 = CType(unaFila.Item(5), Integer)
                c.PROMB = CType(unaFila.Item(6), Double)
                c.RESD1 = CType(unaFila.Item(7), Integer)
                c.RESD2 = CType(unaFila.Item(8), Integer)
                c.PROMD = CType(unaFila.Item(9), Double)
                c.PROMEDIO = CType(unaFila.Item(10), Double)
                c.DIFMAX = CType(unaFila.Item(11), Integer)
                c.DIF = CType(unaFila.Item(12), Integer)
                c.ALERTA = CType(unaFila.Item(13), Integer)
                c.PORCENTAJE = CType(unaFila.Item(14), Double)
                c.RESULTADO = CType(unaFila.Item(15), Integer)
                Return c
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, fecha, operador, muestra, resb1, resb2, promb, resd1, resd2, promd, promedio, difmax, dif, alerta, porcentaje, resultado FROM rglab58_informes order by fecha desc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dRgLab58_informes
                    c.ID = CType(unaFila.Item(0), Long)
                    c.FECHA = CType(unaFila.Item(1), String)
                    c.OPERADOR = CType(unaFila.Item(2), Integer)
                    c.MUESTRA = CType(unaFila.Item(3), Integer)
                    c.RESB1 = CType(unaFila.Item(4), Integer)
                    c.RESB2 = CType(unaFila.Item(5), Integer)
                    c.PROMB = CType(unaFila.Item(6), Double)
                    c.RESD1 = CType(unaFila.Item(7), Integer)
                    c.RESD2 = CType(unaFila.Item(8), Integer)
                    c.PROMD = CType(unaFila.Item(9), Double)
                    c.PROMEDIO = CType(unaFila.Item(10), Double)
                    c.DIFMAX = CType(unaFila.Item(11), Integer)
                    c.DIF = CType(unaFila.Item(12), Integer)
                    c.ALERTA = CType(unaFila.Item(13), Integer)
                    c.PORCENTAJE = CType(unaFila.Item(14), Double)
                    c.RESULTADO = CType(unaFila.Item(15), Integer)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarfechas() As ArrayList
        Dim sql As String = "SELECT DISTINCT fecha FROM rglab58_informes order by fecha desc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim rg51 As New dRgLab58_informes
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
        Dim sql As String = "SELECT id, fecha, operador, muestra, resb1, resb2, promb, resd1, resd2, promd, promedio, difmax, dif, alerta, porcentaje, resultado FROM rglab58_informes WHERE fecha = '" & fecha & "' AND equipo = '" & equipo & "'order by id asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dRgLab58_informes
                    c.ID = CType(unaFila.Item(0), Long)
                    c.FECHA = CType(unaFila.Item(1), String)
                    c.OPERADOR = CType(unaFila.Item(2), Integer)
                    c.MUESTRA = CType(unaFila.Item(3), Integer)
                    c.RESB1 = CType(unaFila.Item(4), Integer)
                    c.RESB2 = CType(unaFila.Item(5), Integer)
                    c.PROMB = CType(unaFila.Item(6), Double)
                    c.RESD1 = CType(unaFila.Item(7), Integer)
                    c.RESD2 = CType(unaFila.Item(8), Integer)
                    c.PROMD = CType(unaFila.Item(9), Double)
                    c.PROMEDIO = CType(unaFila.Item(10), Double)
                    c.DIFMAX = CType(unaFila.Item(11), Integer)
                    c.DIF = CType(unaFila.Item(12), Integer)
                    c.ALERTA = CType(unaFila.Item(13), Integer)
                    c.PORCENTAJE = CType(unaFila.Item(14), Double)
                    c.RESULTADO = CType(unaFila.Item(15), Integer)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxfecha(ByVal fecha As String) As ArrayList
        Dim sql As String = "SELECT id, fecha, operador, muestra, resb1, resb2, promb, resd1, resd2, promd, promedio, difmax, dif, alerta, porcentaje, resultado FROM rglab58_informes WHERE fecha = '" & fecha & "' order by id asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dRgLab58_informes
                    c.ID = CType(unaFila.Item(0), Long)
                    c.FECHA = CType(unaFila.Item(1), String)
                    c.OPERADOR = CType(unaFila.Item(2), Integer)
                    c.MUESTRA = CType(unaFila.Item(3), Integer)
                    c.RESB1 = CType(unaFila.Item(4), Integer)
                    c.RESB2 = CType(unaFila.Item(5), Integer)
                    c.PROMB = CType(unaFila.Item(6), Double)
                    c.RESD1 = CType(unaFila.Item(7), Integer)
                    c.RESD2 = CType(unaFila.Item(8), Integer)
                    c.PROMD = CType(unaFila.Item(9), Double)
                    c.PROMEDIO = CType(unaFila.Item(10), Double)
                    c.DIFMAX = CType(unaFila.Item(11), Integer)
                    c.DIF = CType(unaFila.Item(12), Integer)
                    c.ALERTA = CType(unaFila.Item(13), Integer)
                    c.PORCENTAJE = CType(unaFila.Item(14), Double)
                    c.RESULTADO = CType(unaFila.Item(15), Integer)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxano(ByVal ano As Integer) As ArrayList
        Dim sql As String = "SELECT DISTINCT (fecha) FROM rglab58_informes WHERE YEAR(fecha) = " & ano & " order by id asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dRgLab58_informes

                    c.FECHA = CType(unaFila.Item(0), String)
                   
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxfecha2(ByVal ano As Integer) As ArrayList
        Dim sql As String = "SELECT id, fecha, operador, muestra, resb1, resb2, promb, resd1, resd2, promd, promedio, difmax, dif, alerta, porcentaje, resultado FROM rglab58_informes WHERE YEAR(fecha) = " & ano & " ORDER BY fecha ASC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dRgLab58_informes
                    c.ID = CType(unaFila.Item(0), Long)
                    c.FECHA = CType(unaFila.Item(1), String)
                    c.OPERADOR = CType(unaFila.Item(2), Integer)
                    c.MUESTRA = CType(unaFila.Item(3), Integer)
                    c.RESB1 = CType(unaFila.Item(4), Integer)
                    c.RESB2 = CType(unaFila.Item(5), Integer)
                    c.PROMB = CType(unaFila.Item(6), Double)
                    c.RESD1 = CType(unaFila.Item(7), Integer)
                    c.RESD2 = CType(unaFila.Item(8), Integer)
                    c.PROMD = CType(unaFila.Item(9), Double)
                    c.PROMEDIO = CType(unaFila.Item(10), Double)
                    c.DIFMAX = CType(unaFila.Item(11), Integer)
                    c.DIF = CType(unaFila.Item(12), Integer)
                    c.ALERTA = CType(unaFila.Item(13), Integer)
                    c.PORCENTAJE = CType(unaFila.Item(14), Double)
                    c.RESULTADO = CType(unaFila.Item(15), Integer)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
