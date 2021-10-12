Public Class pSinVisualizacion
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object) As Boolean
        Dim obj As dSinVisualizacion = CType(o, dSinVisualizacion)
        Dim sql As String = "INSERT INTO sin_visualizacion (id, ficha, fecha, muestras, importe, abonado, visualizacion, fechavisualizacion, observaciones) VALUES (" & obj.ID & "," & obj.FICHA & ", '" & obj.FECHA & "'," & obj.MUESTRAS & ", " & obj.IMPORTE & "," & obj.ABONADO & ", " & obj.VISUALIZACION & ",'" & obj.FECHAVISUALIZACION & "','" & obj.OBSERVACIONES & "')"

        Dim lista As New ArrayList
        lista.Add(sql)

        'Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
        '                         & "VALUES (now(), 'sin_visualizacion', 'alta', last_insert_id(), " & usuario.ID & ")"
        'lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dSinVisualizacion = CType(o, dSinVisualizacion)
        Dim sql As String = "UPDATE sin_visualizacion SET ficha=" & obj.FICHA & ",fecha ='" & obj.FECHA & "',muestras =" & obj.MUESTRAS & ",importe =" & obj.IMPORTE & ", abonado=" & obj.ABONADO & ", visualizacion=" & obj.VISUALIZACION & ",fechavisualizacion='" & obj.FECHAVISUALIZACION & "' observaciones ='" & obj.OBSERVACIONES & "' WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'sin_visualizacion', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function actualizarobservaciones(ByVal o As Object) As Boolean
        Dim obj As dSinVisualizacion = CType(o, dSinVisualizacion)
        Dim sql As String = "UPDATE sin_visualizacion SET observaciones ='" & obj.OBSERVACIONES & "' WHERE ficha = " & obj.FICHA & ""

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dSinVisualizacion = CType(o, dSinVisualizacion)
        Dim sql As String = "DELETE FROM sin_visualizacion WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'sin_visualizacion', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dSinVisualizacion
        Dim obj As dSinVisualizacion = CType(o, dSinVisualizacion)
        Dim c As New dSinVisualizacion
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, ficha, fecha, muestras, importe, abonado, visualizacion, fechavisualizacion, ifnull(observaciones,'') FROM sin_visualizacion WHERE id = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                c.ID = CType(unaFila.Item(0), Long)
                c.FICHA = CType(unaFila.Item(1), Long)
                c.FECHA = CType(unaFila.Item(2), String)
                c.MUESTRAS = CType(unaFila.Item(3), Integer)
                c.IMPORTE = CType(unaFila.Item(4), Double)
                c.ABONADO = CType(unaFila.Item(5), Integer)
                c.VISUALIZACION = CType(unaFila.Item(6), Integer)
                c.FECHAVISUALIZACION = CType(unaFila.Item(7), String)
                c.OBSERVACIONES = CType(unaFila.Item(8), String)
                Return c
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscarxficha(ByVal o As Object) As dSinVisualizacion
        Dim obj As dSinVisualizacion = CType(o, dSinVisualizacion)
        Dim c As New dSinVisualizacion
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, ficha, fecha, muestras, importe, abonado, visualizacion, fechavisualizacion, ifnull(observaciones,'') FROM sin_visualizacion WHERE ficha = " & obj.FICHA & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                c.ID = CType(unaFila.Item(0), Long)
                c.FICHA = CType(unaFila.Item(1), Long)
                c.FECHA = CType(unaFila.Item(2), String)
                c.MUESTRAS = CType(unaFila.Item(3), Integer)
                c.IMPORTE = CType(unaFila.Item(4), Double)
                c.ABONADO = CType(unaFila.Item(5), Integer)
                c.VISUALIZACION = CType(unaFila.Item(6), Integer)
                c.FECHAVISUALIZACION = CType(unaFila.Item(7), String)
                c.OBSERVACIONES = CType(unaFila.Item(8), String)
                Return c
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = ("select id, ficha, fecha, muestras, importe, abonado, visualizacion, fechavisualizacion, ifnull(observaciones,'') FROM sin_visualizacion order by id asc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dSinVisualizacion
                    c.ID = CType(unaFila.Item(0), Long)
                    c.FICHA = CType(unaFila.Item(1), Long)
                    c.FECHA = CType(unaFila.Item(2), String)
                    c.MUESTRAS = CType(unaFila.Item(3), Integer)
                    c.IMPORTE = CType(unaFila.Item(4), Double)
                    c.ABONADO = CType(unaFila.Item(5), Integer)
                    c.VISUALIZACION = CType(unaFila.Item(6), Integer)
                    c.FECHAVISUALIZACION = CType(unaFila.Item(7), String)
                    c.OBSERVACIONES = CType(unaFila.Item(8), String)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarsv() As ArrayList
        Dim sql As String = ("select id, ficha, fecha, muestras, importe, abonado, visualizacion, fechavisualizacion, ifnull(observaciones,'') FROM sin_visualizacion WHERE visualizacion = 0 and abonado=0 order by id asc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dSinVisualizacion
                    c.ID = CType(unaFila.Item(0), Long)
                    c.FICHA = CType(unaFila.Item(1), Long)
                    c.FECHA = CType(unaFila.Item(2), String)
                    c.MUESTRAS = CType(unaFila.Item(3), Integer)
                    c.IMPORTE = CType(unaFila.Item(4), Double)
                    c.ABONADO = CType(unaFila.Item(5), Integer)
                    c.VISUALIZACION = CType(unaFila.Item(6), Integer)
                    c.FECHAVISUALIZACION = CType(unaFila.Item(7), String)
                    c.OBSERVACIONES = CType(unaFila.Item(8), String)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarcv() As ArrayList
        Dim sql As String = ("select id, ficha, fecha, muestras, importe, abonado, visualizacion, fechavisualizacion, ifnull(observaciones,'') FROM sin_visualizacion WHERE visualizacion = 1 order by fechavisualizacion desc LIMIT 50")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dSinVisualizacion
                    c.ID = CType(unaFila.Item(0), Long)
                    c.FICHA = CType(unaFila.Item(1), Long)
                    c.FECHA = CType(unaFila.Item(2), String)
                    c.MUESTRAS = CType(unaFila.Item(3), Integer)
                    c.IMPORTE = CType(unaFila.Item(4), Double)
                    c.ABONADO = CType(unaFila.Item(5), Integer)
                    c.VISUALIZACION = CType(unaFila.Item(6), Integer)
                    c.FECHAVISUALIZACION = CType(unaFila.Item(7), String)
                    c.OBSERVACIONES = CType(unaFila.Item(8), String)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxfecha(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim sql As String = ("select id, ficha, fecha, muestras, importe, abonado, visualizacion, fechavisualizacion, ifnull(observaciones,'') FROM sin_visualizacion WHERE fecha >='" & desde & "' and fecha <='" & hasta & "' AND controlado = 1 order by tipo asc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dSinVisualizacion
                    c.ID = CType(unaFila.Item(0), Long)
                    c.FICHA = CType(unaFila.Item(1), Long)
                    c.FECHA = CType(unaFila.Item(2), String)
                    c.MUESTRAS = CType(unaFila.Item(3), Integer)
                    c.IMPORTE = CType(unaFila.Item(4), Double)
                    c.ABONADO = CType(unaFila.Item(5), Integer)
                    c.VISUALIZACION = CType(unaFila.Item(6), Integer)
                    c.FECHAVISUALIZACION = CType(unaFila.Item(7), String)
                    c.OBSERVACIONES = CType(unaFila.Item(8), String)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function marcarvisualizacion(ByVal o As Object, ByVal usuario As dUsuario, ByVal fec As String) As Boolean
        Dim obj As dSinVisualizacion = CType(o, dSinVisualizacion)
        Dim sql As String = "UPDATE sin_visualizacion SET visualizacion=1, fechavisualizacion = '" & fec & "' WHERE visualizacion=0 and ID = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function desmarcarvisualizacion(ByVal o As Object, ByVal usuario As dUsuario, ByVal fec As String) As Boolean
        Dim obj As dSinVisualizacion = CType(o, dSinVisualizacion)
        Dim sql As String = "UPDATE sin_visualizacion SET visualizacion=0, fechavisualizacion = '" & fec & "' WHERE visualizacion=1 and ID = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function guardarobservaciones(ByVal o As Object, ByVal usuario As dUsuario, ByVal obs As String) As Boolean
        Dim obj As dSinVisualizacion = CType(o, dSinVisualizacion)
        Dim sql As String = "UPDATE sin_visualizacion SET observaciones='" & obs & "' WHERE ID = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function guardarmuestras(ByVal o As Object, ByVal usuario As dUsuario, ByVal muestras As Integer) As Boolean
        Dim obj As dSinVisualizacion = CType(o, dSinVisualizacion)
        Dim sql As String = "UPDATE sin_visualizacion SET muestras=" & muestras & " WHERE ID = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function guardarimporte(ByVal o As Object, ByVal usuario As dUsuario, ByVal importe As Double) As Boolean
        Dim obj As dSinVisualizacion = CType(o, dSinVisualizacion)
        Dim sql As String = "UPDATE sin_visualizacion SET importe=" & importe & " WHERE ID = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function marcarabonado(ByVal o As Object, ByVal usuario As dUsuario, ByVal fec As String) As Boolean
        Dim obj As dSinVisualizacion = CType(o, dSinVisualizacion)
        Dim sql As String = "UPDATE sin_visualizacion SET abonado=1, fechavisualizacion = '" & fec & "' WHERE abonado=0 and ID = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function desmarcarabonado(ByVal o As Object, ByVal usuario As dUsuario, ByVal fec As String) As Boolean
        Dim obj As dSinVisualizacion = CType(o, dSinVisualizacion)
        Dim sql As String = "UPDATE sin_visualizacion SET abonado=0, fechavisualizacion = '" & fec & "' WHERE abonado=1 and ID = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Return EjecutarTransaccion(lista)
    End Function
End Class
