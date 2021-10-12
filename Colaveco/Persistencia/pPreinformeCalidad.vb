Public Class pPreinformeCalidad
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object) As Boolean
        Dim obj As dPreinformeCalidad = CType(o, dPreinformeCalidad)
        Dim sql As String = "INSERT INTO preinforme_calidad (id, ficha, creado, abonado, comentario, copia, parasubir, subido, fecha) VALUES (" & obj.ID & ", " & obj.FICHA & ", " & obj.CREADO & ", " & obj.ABONADO & ", '" & obj.COMENTARIO & "', '" & obj.COPIA & "', " & obj.PARASUBIR & ", " & obj.SUBIDO & ", '" & obj.FECHA & "')"

        Dim lista As New ArrayList
        lista.Add(sql)

        'Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
        '                         & "VALUES (now(), 'preinforme_calidad', 'alta', last_insert_id(), " & usuario.ID & ")"
        'lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object) As Boolean
        Dim obj As dPreinformeCalidad = CType(o, dPreinformeCalidad)
        Dim sql As String = "UPDATE preinforme_calidad SET ficha = " & obj.FICHA & ", creado= " & obj.CREADO & ", abonado=" & obj.ABONADO & ", comentario = '" & obj.COMENTARIO & "', copia = '" & obj.COPIA & "', parasubir=" & obj.PARASUBIR & ", subido=" & obj.SUBIDO & ", fecha='" & obj.FECHA & "' WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        'Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
        '                         & "VALUES (now(), 'preinforme_calidad', 'creado', " & obj.ID & ", " & usuario.ID & ")"
        'lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar2(ByVal o As Object) As Boolean
        Dim obj As dPreinformeCalidad = CType(o, dPreinformeCalidad)
        Dim sql As String = "UPDATE preinforme_calidad SET abonado=" & obj.ABONADO & ", comentario = '" & obj.COMENTARIO & "', copia = '" & obj.COPIA & "', parasubir = " & obj.PARASUBIR & " WHERE ficha = " & obj.FICHA & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        'Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
        '                         & "VALUES (now(), 'preinforme_calidad', 'creado', " & obj.ID & ", " & usuario.ID & ")"
        'lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function marcarcreado(ByVal o As Object) As Boolean
        Dim obj As dPreinformeCalidad = CType(o, dPreinformeCalidad)
        Dim sql As String = "UPDATE preinforme_calidad SET creado= 1 WHERE ficha = " & obj.FICHA & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        'Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
        '                         & "VALUES (now(), 'preinforme_calidad', 'creado', " & obj.ID & ", " & usuario.ID & ")"
        'lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    
    Public Function marcarsubido(ByVal o As Object, ByVal fecha As String) As Boolean
        Dim obj As dPreinformeCalidad = CType(o, dPreinformeCalidad)
        Dim sql As String = "UPDATE preinforme_calidad SET subido= 1, fecha= '" & fecha & "' WHERE ficha = " & obj.FICHA & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        'Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
        '                         & "VALUES (now(), 'preinforme_calidad', 'creado', " & obj.ID & ", " & usuario.ID & ")"
        'lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dPreinformeCalidad = CType(o, dPreinformeCalidad)
        Dim sql As String = "DELETE FROM preinforme_calidad WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'preinforme_calidad', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dPreinformeCalidad
        Dim obj As dPreinformeCalidad = CType(o, dPreinformeCalidad)
        Dim l As New dPreinformeCalidad
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, ficha, creado, abonado, comentario, copia, parasubir, subido, fecha FROM preinforme_calidad WHERE ficha = " & obj.FICHA & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                l.ID = CType(unaFila.Item(0), Long)
                l.FICHA = CType(unaFila.Item(1), Long)
                l.CREADO = CType(unaFila.Item(2), Integer)
                l.ABONADO = CType(unaFila.Item(3), Integer)
                l.COMENTARIO = CType(unaFila.Item(4), String)
                l.COPIA = CType(unaFila.Item(5), String)
                l.PARASUBIR = CType(unaFila.Item(6), Integer)
                l.SUBIDO = CType(unaFila.Item(7), Integer)
                l.FECHA = CType(unaFila.Item(8), String)
                Return l
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, ficha, creado, abonado, comentario, copia, parasubir, subido, fecha FROM preinforme_calidad"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dPreinformeCalidad
                    l.ID = CType(unaFila.Item(0), Long)
                    l.FICHA = CType(unaFila.Item(1), Long)
                    l.CREADO = CType(unaFila.Item(2), Integer)
                    l.ABONADO = CType(unaFila.Item(3), Integer)
                    l.COMENTARIO = CType(unaFila.Item(4), String)
                    l.COPIA = CType(unaFila.Item(5), String)
                    l.PARASUBIR = CType(unaFila.Item(6), Integer)
                    l.SUBIDO = CType(unaFila.Item(7), Integer)
                    l.FECHA = CType(unaFila.Item(8), String)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarsinmarcar() As ArrayList
        Dim sql As String = "SELECT id, ficha, creado, abonado, ifnull(comentario,''),ifnull(copia,''), parasubir, subido, fecha FROM preinforme_calidad WHERE creado =0"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dPreinformeCalidad
                    l.ID = CType(unaFila.Item(0), Long)
                    l.FICHA = CType(unaFila.Item(1), Long)
                    l.CREADO = CType(unaFila.Item(2), Integer)
                    l.ABONADO = CType(unaFila.Item(3), Integer)
                    l.COMENTARIO = CType(unaFila.Item(4), String)
                    l.COPIA = CType(unaFila.Item(5), String)
                    l.PARASUBIR = CType(unaFila.Item(6), Integer)
                    l.SUBIDO = CType(unaFila.Item(7), Integer)
                    l.FECHA = CType(unaFila.Item(8), String)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarparasubir() As ArrayList
        Dim sql As String = "SELECT id, ficha, creado, abonado, ifnull(comentario,''),ifnull(copia,''), parasubir, subido, fecha FROM preinforme_calidad WHERE parasubir =1 AND subido = 0"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dPreinformeCalidad
                    l.ID = CType(unaFila.Item(0), Long)
                    l.FICHA = CType(unaFila.Item(1), Long)
                    l.CREADO = CType(unaFila.Item(2), Integer)
                    l.ABONADO = CType(unaFila.Item(3), Integer)
                    l.COMENTARIO = CType(unaFila.Item(4), String)
                    l.COPIA = CType(unaFila.Item(5), String)
                    l.PARASUBIR = CType(unaFila.Item(6), Integer)
                    l.SUBIDO = CType(unaFila.Item(7), Integer)
                    l.FECHA = CType(unaFila.Item(8), String)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarsubidas() As ArrayList
        Dim sql As String = "SELECT id, ficha, creado, abonado, ifnull(comentario,''),ifnull(copia,''), parasubir, subido, fecha FROM preinforme_calidad WHERE parasubir =1 AND subido = 1 ORDER BY FECHA DESC LIMIT 30"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dPreinformeCalidad
                    l.ID = CType(unaFila.Item(0), Long)
                    l.FICHA = CType(unaFila.Item(1), Long)
                    l.CREADO = CType(unaFila.Item(2), Integer)
                    l.ABONADO = CType(unaFila.Item(3), Integer)
                    l.COMENTARIO = CType(unaFila.Item(4), String)
                    l.COPIA = CType(unaFila.Item(5), String)
                    l.PARASUBIR = CType(unaFila.Item(6), Integer)
                    l.SUBIDO = CType(unaFila.Item(7), Integer)
                    l.FECHA = CType(unaFila.Item(8), String)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
