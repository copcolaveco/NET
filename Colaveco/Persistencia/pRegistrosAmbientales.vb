Public Class pRegistrosAmbientales
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dRegistrosAmbientales = CType(o, dRegistrosAmbientales)
        Dim sql As String = "INSERT INTO registros_ambientales (id, sector, fecha, hora, temperatura, humedad) VALUES (" & obj.ID & ", '" & obj.SECTOR & "','" & obj.FECHA & "','" & obj.HORA & "'," & obj.TEMPERATURA & "," & obj.HUMEDAD & " )"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'resgistros_ambientales', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dRegistrosAmbientales = CType(o, dRegistrosAmbientales)
        Dim sql As String = "UPDATE registros_ambientales SET sectro= '" & obj.SECTOR & "', fecha ='" & obj.FECHA & "',hora ='" & obj.HORA & "',,temperatura = " & obj.TEMPERATURA & ",humedad = " & obj.HUMEDAD & " WHERE ID = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'resgistros_ambientales', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dRegistrosAmbientales = CType(o, dRegistrosAmbientales)
        Dim sql As String = "DELETE FROM registros_ambientales WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'resgistros_ambientales', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function

    Public Function buscar(ByVal o As Object) As dRegistrosAmbientales
        Dim obj As dRegistrosAmbientales = CType(o, dRegistrosAmbientales)
        Dim c As New dRegistrosAmbientales
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, sector,fecha, hora,  temperatura, humedad FROM registros_ambientales WHERE id = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                c.ID = CType(unaFila.Item(0), Long)
                c.SECTOR = CType(unaFila.Item(1), String)
                c.FECHA = CType(unaFila.Item(2), String)
                c.HORA = CType(unaFila.Item(3), String)
                c.TEMPERATURA = CType(unaFila.Item(4), Double)
                c.HUMEDAD = CType(unaFila.Item(5), Double)
                Return c
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, sector, fecha, hora, temperatura, humedad FROM registros_ambientales order by fecha desc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dRegistrosAmbientales
                    c.ID = CType(unaFila.Item(0), Long)
                    c.SECTOR = CType(unaFila.Item(1), String)
                    c.FECHA = CType(unaFila.Item(2), String)
                    c.HORA = CType(unaFila.Item(3), String)
                    c.TEMPERATURA = CType(unaFila.Item(4), Double)
                    c.HUMEDAD = CType(unaFila.Item(5), Double)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscarultimofq(ByVal o As Object) As dRegistrosAmbientales
        Dim obj As dRegistrosAmbientales = CType(o, dRegistrosAmbientales)
        Dim c As New dRegistrosAmbientales
        Dim sector As String = "fq"
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT fecha, hora, temperatura, humedad FROM registros_ambientales where sector= '" & sector & "' AND fecha = (SELECT MAX(fecha) FROM registros_ambientales)")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                c.FECHA = CType(unaFila.Item(0), String)
                c.HORA = CType(unaFila.Item(1), String)
                c.TEMPERATURA = CType(unaFila.Item(2), Double)
                c.HUMEDAD = CType(unaFila.Item(3), Double)
                Return c
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscarultimomicro(ByVal o As Object) As dRegistrosAmbientales
        Dim obj As dRegistrosAmbientales = CType(o, dRegistrosAmbientales)
        Dim c As New dRegistrosAmbientales
        Dim sector As String = "micro"
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT fecha, hora, temperatura, humedad FROM registros_ambientales where sector= '" & sector & "' AND fecha = (SELECT MAX(fecha) FROM registros_ambientales)")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                c.FECHA = CType(unaFila.Item(0), String)
                c.HORA = CType(unaFila.Item(1), String)
                c.TEMPERATURA = CType(unaFila.Item(2), Double)
                c.HUMEDAD = CType(unaFila.Item(3), Double)
                Return c
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
