Imports System.Text

Public Class pPreinformes
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object) As Boolean
        Dim obj As dPreinformes = CType(o, dPreinformes)
        Dim sql As String = "INSERT INTO preinformes (id, ficha, tipo, creado, abonado, comentario, copia, parasubir, subido, fecha, control) VALUES (" & obj.ID & ", " & obj.FICHA & ", " & obj.TIPO & ", " & obj.CREADO & ", " & obj.ABONADO & ", '" & obj.COMENTARIO & "', '" & obj.COPIA & "', " & obj.PARASUBIR & ", " & obj.SUBIDO & ", '" & obj.FECHA & "', " & obj.CONTROL & ")"

        Dim lista As New ArrayList
        lista.Add(sql)

        'Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
        '                         & "VALUES (now(), 'preinformes', 'alta', last_insert_id(), " & usuario.ID & ")"
        'lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object) As Boolean
        Dim obj As dPreinformes = CType(o, dPreinformes)
        Dim sql As String = "UPDATE preinformes SET ficha = " & obj.FICHA & ",tipo = " & obj.TIPO & ", creado= " & obj.CREADO & ", abonado=" & obj.ABONADO & ", comentario = '" & obj.COMENTARIO & "', copia = '" & obj.COPIA & "', parasubir=" & obj.PARASUBIR & ", subido=" & obj.SUBIDO & ", fecha='" & obj.FECHA & "', control=" & obj.CONTROL & " WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        'Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
        '                         & "VALUES (now(), 'preinformes', 'creado', " & obj.ID & ", " & usuario.ID & ")"
        'lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar2(ByVal o As Object) As Boolean
        Dim obj As dPreinformes = CType(o, dPreinformes)
        Dim sql As String = "UPDATE preinformes SET abonado=" & obj.ABONADO & ", comentario = '" & obj.COMENTARIO & "', copia = '" & obj.COPIA & "', parasubir = " & obj.PARASUBIR & ", fecha = '" & obj.FECHA & "' WHERE ficha = " & obj.FICHA & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        'Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
        '                         & "VALUES (now(), 'preinformes', 'creado', " & obj.ID & ", " & usuario.ID & ")"
        'lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar3(ByVal o As Object) As Boolean
        Dim obj As dPreinformes = CType(o, dPreinformes)
        Dim sql As String = "UPDATE preinformes SET parasubir = " & obj.PARASUBIR & ", subido = " & obj.SUBIDO & " WHERE ficha = " & obj.FICHA & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        'Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
        '                         & "VALUES (now(), 'preinformes', 'creado', " & obj.ID & ", " & usuario.ID & ")"
        'lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function marcarcreado(ByVal o As Object) As Boolean
        Dim obj As dPreinformes = CType(o, dPreinformes)
        Dim sql As String = "UPDATE preinformes SET creado= 1 WHERE ficha = " & obj.FICHA & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        'Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
        '                         & "VALUES (now(), 'preinformes', 'creado', " & obj.ID & ", " & usuario.ID & ")"
        'lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function desmarcarcreadoysubir(ByVal o As Object) As Boolean
        Dim obj As dPreinformes = CType(o, dPreinformes)
        Dim sql As String = "UPDATE preinformes SET creado= 0, abonado=0, parasubir=0  WHERE ficha = " & obj.FICHA & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        'Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
        '                         & "VALUES (now(), 'preinformes', 'creado', " & obj.ID & ", " & usuario.ID & ")"
        'lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function

    Public Function marcarsubido(ByVal o As Object, ByVal fecha As String) As Boolean
        Dim obj As dPreinformes = CType(o, dPreinformes)
        Dim sql As String = "UPDATE preinformes SET subido= 1, fecha= '" & fecha & "' WHERE ficha = " & obj.FICHA & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        'Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
        '                         & "VALUES (now(), 'preinformes', 'creado', " & obj.ID & ", " & usuario.ID & ")"
        'lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function marcarcontrolado(ByVal o As Object) As Boolean
        Dim obj As dPreinformes = CType(o, dPreinformes)
        Dim sql As String = "UPDATE preinformes SET control= 0 WHERE ficha = " & obj.FICHA & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        'Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
        '                         & "VALUES (now(), 'preinformes', 'creado', " & obj.ID & ", " & usuario.ID & ")"
        'lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dPreinformes = CType(o, dPreinformes)
        Dim sql As String = "DELETE FROM preinformes WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'preinformes', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dPreinformes
        Dim obj As dPreinformes = CType(o, dPreinformes)
        Dim p As New dPreinformes
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, ficha, tipo, creado, abonado, comentario, copia, parasubir, subido, fecha, control FROM preinformes WHERE ficha = " & obj.FICHA & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                p.ID = CType(unaFila.Item(0), Long)
                p.FICHA = CType(unaFila.Item(1), Long)
                p.TIPO = CType(unaFila.Item(2), Integer)
                p.CREADO = CType(unaFila.Item(3), Integer)
                p.ABONADO = CType(unaFila.Item(4), Integer)
                p.COMENTARIO = CType(unaFila.Item(5), String)
                p.COPIA = CType(unaFila.Item(6), String)
                p.PARASUBIR = CType(unaFila.Item(7), Integer)
                p.SUBIDO = CType(unaFila.Item(8), Integer)
                p.FECHA = CType(unaFila.Item(9), String)
                p.CONTROL = CType(unaFila.Item(10), Integer)
                Return p
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, ficha, tipo, creado, abonado, comentario, copia, parasubir, subido, fecha, control FROM preinformes"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dPreinformes
                    p.ID = CType(unaFila.Item(0), Long)
                    p.FICHA = CType(unaFila.Item(1), Long)
                    p.TIPO = CType(unaFila.Item(2), Integer)
                    p.CREADO = CType(unaFila.Item(3), Integer)
                    p.ABONADO = CType(unaFila.Item(4), Integer)
                    p.COMENTARIO = CType(unaFila.Item(5), String)
                    p.COPIA = CType(unaFila.Item(6), String)
                    p.PARASUBIR = CType(unaFila.Item(7), Integer)
                    p.SUBIDO = CType(unaFila.Item(8), Integer)
                    p.FECHA = CType(unaFila.Item(9), String)
                    p.CONTROL = CType(unaFila.Item(10), Integer)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarsinmarcar() As ArrayList
        Dim sql As String = "SELECT id, ficha, tipo, creado, abonado, ifnull(comentario,''),ifnull(copia,''), parasubir, subido, fecha, control FROM preinformes WHERE creado =0 and ficha > 0 "
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dPreinformes
                    p.ID = CType(unaFila.Item(0), Long)
                    p.FICHA = CType(unaFila.Item(1), Long)
                    p.TIPO = CType(unaFila.Item(2), Integer)
                    p.CREADO = CType(unaFila.Item(3), Integer)
                    p.ABONADO = CType(unaFila.Item(4), Integer)
                    p.COMENTARIO = CType(unaFila.Item(5), String)
                    p.COPIA = CType(unaFila.Item(6), String)
                    p.PARASUBIR = CType(unaFila.Item(7), Integer)
                    p.SUBIDO = CType(unaFila.Item(8), Integer)
                    p.FECHA = CType(unaFila.Item(9), String)
                    p.CONTROL = CType(unaFila.Item(10), Integer)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarsinmarcarcalidad() As ArrayList
        Dim sql As String = "SELECT id, ficha, tipo, creado, abonado, ifnull(comentario,''),ifnull(copia,''), parasubir, subido, fecha, control FROM preinformes WHERE creado =0 AND tipo = 10"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dPreinformes
                    p.ID = CType(unaFila.Item(0), Long)
                    p.FICHA = CType(unaFila.Item(1), Long)
                    p.TIPO = CType(unaFila.Item(2), Integer)
                    p.CREADO = CType(unaFila.Item(3), Integer)
                    p.ABONADO = CType(unaFila.Item(4), Integer)
                    p.COMENTARIO = CType(unaFila.Item(5), String)
                    p.COPIA = CType(unaFila.Item(6), String)
                    p.PARASUBIR = CType(unaFila.Item(7), Integer)
                    p.SUBIDO = CType(unaFila.Item(8), Integer)
                    p.FECHA = CType(unaFila.Item(9), String)
                    p.CONTROL = CType(unaFila.Item(10), Integer)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarsinmarcarcontrol() As ArrayList
        Dim sql As String = "SELECT id, ficha, tipo, creado, abonado, ifnull(comentario,''),ifnull(copia,''), parasubir, subido, fecha, control FROM preinformes WHERE creado =0 AND tipo = 1"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dPreinformes
                    p.ID = CType(unaFila.Item(0), Long)
                    p.FICHA = CType(unaFila.Item(1), Long)
                    p.TIPO = CType(unaFila.Item(2), Integer)
                    p.CREADO = CType(unaFila.Item(3), Integer)
                    p.ABONADO = CType(unaFila.Item(4), Integer)
                    p.COMENTARIO = CType(unaFila.Item(5), String)
                    p.COPIA = CType(unaFila.Item(6), String)
                    p.PARASUBIR = CType(unaFila.Item(7), Integer)
                    p.SUBIDO = CType(unaFila.Item(8), Integer)
                    p.FECHA = CType(unaFila.Item(9), String)
                    p.CONTROL = CType(unaFila.Item(10), Integer)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarsincontrolclechero(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim sql As String = "SELECT id, ficha, tipo, creado, abonado, ifnull(comentario,''),ifnull(copia,''), parasubir, subido, fecha, control FROM preinformes WHERE tipo = 1 AND parasubir = 1 AND control = 0 AND fecha BETWEEN '" & desde & "' AND '" & hasta & "' ORDER BY RAND() LIMIT 5"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dPreinformes
                    p.ID = CType(unaFila.Item(0), Long)
                    p.FICHA = CType(unaFila.Item(1), Long)
                    p.TIPO = CType(unaFila.Item(2), Integer)
                    p.CREADO = CType(unaFila.Item(3), Integer)
                    p.ABONADO = CType(unaFila.Item(4), Integer)
                    p.COMENTARIO = CType(unaFila.Item(5), String)
                    p.COPIA = CType(unaFila.Item(6), String)
                    p.PARASUBIR = CType(unaFila.Item(7), Integer)
                    p.SUBIDO = CType(unaFila.Item(8), Integer)
                    p.FECHA = CType(unaFila.Item(9), String)
                    p.CONTROL = CType(unaFila.Item(10), Integer)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarsincontrolcalidad(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim sql As String = "SELECT id, ficha, tipo, creado, abonado, ifnull(comentario,''),ifnull(copia,''), parasubir, subido, fecha, control FROM preinformes WHERE tipo = 10 AND parasubir = 1 AND control = 0 AND fecha BETWEEN '" & desde & "' AND '" & hasta & "' ORDER BY RAND() LIMIT 5"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dPreinformes
                    p.ID = CType(unaFila.Item(0), Long)
                    p.FICHA = CType(unaFila.Item(1), Long)
                    p.TIPO = CType(unaFila.Item(2), Integer)
                    p.CREADO = CType(unaFila.Item(3), Integer)
                    p.ABONADO = CType(unaFila.Item(4), Integer)
                    p.COMENTARIO = CType(unaFila.Item(5), String)
                    p.COPIA = CType(unaFila.Item(6), String)
                    p.PARASUBIR = CType(unaFila.Item(7), Integer)
                    p.SUBIDO = CType(unaFila.Item(8), Integer)
                    p.FECHA = CType(unaFila.Item(9), String)
                    p.CONTROL = CType(unaFila.Item(10), Integer)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarsincontrolagua(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim sql As String = "SELECT id, ficha, tipo, creado, abonado, ifnull(comentario,''),ifnull(copia,''), parasubir, subido, fecha, control FROM preinformes WHERE tipo = 3 AND parasubir = 1 AND control = 0 AND fecha BETWEEN '" & desde & "' AND '" & hasta & "' ORDER BY RAND() LIMIT 5"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dPreinformes
                    p.ID = CType(unaFila.Item(0), Long)
                    p.FICHA = CType(unaFila.Item(1), Long)
                    p.TIPO = CType(unaFila.Item(2), Integer)
                    p.CREADO = CType(unaFila.Item(3), Integer)
                    p.ABONADO = CType(unaFila.Item(4), Integer)
                    p.COMENTARIO = CType(unaFila.Item(5), String)
                    p.COPIA = CType(unaFila.Item(6), String)
                    p.PARASUBIR = CType(unaFila.Item(7), Integer)
                    p.SUBIDO = CType(unaFila.Item(8), Integer)
                    p.FECHA = CType(unaFila.Item(9), String)
                    p.CONTROL = CType(unaFila.Item(10), Integer)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarsincontrolsubproductos(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim sql As String = "SELECT id, ficha, tipo, creado, abonado, ifnull(comentario,''),ifnull(copia,''), parasubir, subido, fecha, control FROM preinformes WHERE tipo = 7 AND parasubir = 1 AND control = 0 AND fecha BETWEEN '" & desde & "' AND '" & hasta & "' ORDER BY RAND() LIMIT 5"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dPreinformes
                    p.ID = CType(unaFila.Item(0), Long)
                    p.FICHA = CType(unaFila.Item(1), Long)
                    p.TIPO = CType(unaFila.Item(2), Integer)
                    p.CREADO = CType(unaFila.Item(3), Integer)
                    p.ABONADO = CType(unaFila.Item(4), Integer)
                    p.COMENTARIO = CType(unaFila.Item(5), String)
                    p.COPIA = CType(unaFila.Item(6), String)
                    p.PARASUBIR = CType(unaFila.Item(7), Integer)
                    p.SUBIDO = CType(unaFila.Item(8), Integer)
                    p.FECHA = CType(unaFila.Item(9), String)
                    p.CONTROL = CType(unaFila.Item(10), Integer)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarparasubir() As ArrayList
        Dim sql As String = "SELECT id, ficha, tipo, creado, abonado, ifnull(comentario,''),ifnull(copia,''), parasubir, subido, fecha, control FROM preinformes WHERE parasubir =1 AND subido = 0"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dPreinformes
                    p.ID = CType(unaFila.Item(0), Long)
                    p.FICHA = CType(unaFila.Item(1), Long)
                    p.TIPO = CType(unaFila.Item(2), Integer)
                    p.CREADO = CType(unaFila.Item(3), Integer)
                    p.ABONADO = CType(unaFila.Item(4), Integer)
                    p.COMENTARIO = CType(unaFila.Item(5), String)
                    p.COPIA = CType(unaFila.Item(6), String)
                    p.PARASUBIR = CType(unaFila.Item(7), Integer)
                    p.SUBIDO = CType(unaFila.Item(8), Integer)
                    p.FECHA = CType(unaFila.Item(9), String)
                    p.CONTROL = CType(unaFila.Item(10), Integer)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarparasubidos(ByVal fecha_desde As String, ByVal fecha_hasta As String) As ArrayList
        Dim sql As String = "SELECT pi.id, pi.ficha, pi.tipo, pi.creado, pi.abonado, ifnull(pi.comentario,''),ifnull(pi.copia,''), pi.parasubir, pi.subido, pi.fecha, pi.control FROM preinformes pi inner join solicitudanalisis sa on sa.id = pi.ficha WHERE pi.parasubir =1 AND pi.subido = 1 AND sa.fechaingreso >= '" & fecha_desde & "' AND sa.fechaingreso <= '" & fecha_hasta & "'"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dPreinformes
                    p.ID = CType(unaFila.Item(0), Long)
                    p.FICHA = CType(unaFila.Item(1), Long)
                    p.TIPO = CType(unaFila.Item(2), Integer)
                    p.CREADO = CType(unaFila.Item(3), Integer)
                    p.ABONADO = CType(unaFila.Item(4), Integer)
                    p.COMENTARIO = CType(unaFila.Item(5), String)
                    p.COPIA = CType(unaFila.Item(6), String)
                    p.PARASUBIR = CType(unaFila.Item(7), Integer)
                    p.SUBIDO = CType(unaFila.Item(8), Integer)
                    p.FECHA = CType(unaFila.Item(9), String)
                    p.CONTROL = CType(unaFila.Item(10), Integer)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
        
    Public Function listar_informes_gestor(ByVal desde As String, ByVal hasta As String, ByVal filtroEstado As String, ByVal ficha As String) As ArrayList
        Dim sql As New StringBuilder()
        Dim filtroFicha As String = ""

        ' Validar si ficha tiene valor y es numérica
        If Not String.IsNullOrEmpty(ficha) AndAlso IsNumeric(ficha) Then
            filtroFicha = " AND sa.id = " & ficha & " "
        End If

        If filtroEstado = "SUBIDO" Or filtroEstado = "AMBOS" Then
            sql.Append("SELECT sa.id AS ficha, sa.fechaingreso, c.nombre AS cliente, ti.nombre AS tipoinforme, 'SUBIDO' AS estado ")
            sql.Append("FROM solicitudanalisis sa ")
            sql.Append("INNER JOIN cliente c ON c.id = sa.idproductor ")
            sql.Append("INNER JOIN tipoinforme ti ON ti.id = sa.idtipoinforme ")
            sql.Append("WHERE sa.marca = 1 AND (")
            sql.Append("EXISTS (SELECT 1 FROM controlinformesfq WHERE ficha = sa.id AND controlado = 1) ")
            sql.Append("OR EXISTS (SELECT 1 FROM controlinformesmicro WHERE ficha = sa.id AND controlado = 1) ")
            sql.Append("OR EXISTS (SELECT 1 FROM controlinformesefluentes WHERE ficha = sa.id AND controlado = 1) ")
            sql.Append("OR EXISTS (SELECT 1 FROM controlinformesnutricion WHERE ficha = sa.id AND controlado = 1) ")
            sql.Append("OR EXISTS (SELECT 1 FROM controlinformessuelos WHERE ficha = sa.id AND controlado = 1)) ")
            sql.Append("AND sa.FECHAENVIO BETWEEN '" & desde & "' AND '" & hasta & "' ")
            sql.Append(filtroFicha)
        End If

        If filtroEstado = "AMBOS" Then
            sql.Append("UNION ")
        End If

        If filtroEstado = "PENDIENTE" Or filtroEstado = "AMBOS" Then
            sql.Append("SELECT sa.id AS ficha, sa.fechaingreso, c.nombre AS cliente, ti.nombre AS tipoinforme, 'PENDIENTE' AS estado ")
            sql.Append("FROM solicitudanalisis sa ")
            sql.Append("INNER JOIN cliente c ON c.id = sa.idproductor ")
            sql.Append("INNER JOIN tipoinforme ti ON ti.id = sa.idtipoinforme ")
            sql.Append("WHERE (sa.marca = 0 OR ")
            sql.Append("EXISTS (SELECT 1 FROM controlinformesfq WHERE ficha = sa.id AND controlado = 0) ")
            sql.Append("OR EXISTS (SELECT 1 FROM controlinformesmicro WHERE ficha = sa.id AND controlado = 0) ")
            sql.Append("OR EXISTS (SELECT 1 FROM controlinformesefluentes WHERE ficha = sa.id AND controlado = 0) ")
            sql.Append("OR EXISTS (SELECT 1 FROM controlinformesnutricion WHERE ficha = sa.id AND controlado = 0) ")
            sql.Append("OR EXISTS (SELECT 1 FROM controlinformessuelos WHERE ficha = sa.id AND controlado = 0)) ")
            sql.Append("AND sa.FECHAENVIO BETWEEN '" & desde & "' AND '" & hasta & "' ")
            sql.Append(filtroFicha)
        End If

        sql.Append("ORDER BY fechaingreso DESC")

        Try
            Dim lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql.ToString())

            For Each fila As DataRow In Ds.Tables(0).Rows
                Dim i As New dInformeGestor
                i.FICHA = CType(fila.Item("ficha"), Long)
                i.FECHAINGRESO = CType(fila.Item("fechaingreso"), String)
                i.CLIENTE = CType(fila.Item("cliente"), String)
                i.TIPOINFORME = CType(fila.Item("tipoinforme"), String)
                i.ESTADO = CType(fila.Item("estado"), String)
                lista.Add(i)
            Next
            Return lista
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function listar_informes_gestor_deldia() As ArrayList
        Dim sql As New StringBuilder()

        sql.Append("SELECT sa.id AS ficha, sa.fechaingreso, sa.fechaenvio, c.nombre AS cliente, ti.nombre AS tipoinforme, 'SUBIDO' AS estado ")
        sql.Append("FROM solicitudanalisis sa ")
        sql.Append("INNER JOIN cliente c ON c.id = sa.idproductor ")
        sql.Append("INNER JOIN tipoinforme ti ON ti.id = sa.idtipoinforme ")
        sql.Append("WHERE sa.marca = 1 AND (")
        sql.Append("EXISTS (SELECT 1 FROM controlinformesfq WHERE ficha = sa.id AND controlado = 1) ")
        sql.Append("OR EXISTS (SELECT 1 FROM controlinformesmicro WHERE ficha = sa.id AND controlado = 1) ")
        sql.Append("OR EXISTS (SELECT 1 FROM controlinformesefluentes WHERE ficha = sa.id AND controlado = 1) ")
        sql.Append("OR EXISTS (SELECT 1 FROM controlinformesnutricion WHERE ficha = sa.id AND controlado = 1) ")
        sql.Append("OR EXISTS (SELECT 1 FROM controlinformessuelos WHERE ficha = sa.id AND controlado = 1)) ")
        sql.Append("AND sa.FECHAENVIO BETWEEN CURDATE() AND CURDATE() ")

        sql.Append(" UNION ")

        sql.Append("SELECT sa.id AS ficha, sa.fechaingreso, sa.fechaenvio, c.nombre AS cliente, ti.nombre AS tipoinforme, 'PENDIENTE' AS estado ")
        sql.Append("FROM solicitudanalisis sa ")
        sql.Append("INNER JOIN cliente c ON c.id = sa.idproductor ")
        sql.Append("INNER JOIN tipoinforme ti ON ti.id = sa.idtipoinforme ")
        sql.Append("WHERE (sa.marca = 0 OR ")
        sql.Append("EXISTS (SELECT 1 FROM controlinformesfq WHERE ficha = sa.id AND controlado = 0) ")
        sql.Append("OR EXISTS (SELECT 1 FROM controlinformesmicro WHERE ficha = sa.id AND controlado = 0) ")
        sql.Append("OR EXISTS (SELECT 1 FROM controlinformesefluentes WHERE ficha = sa.id AND controlado = 0) ")
        sql.Append("OR EXISTS (SELECT 1 FROM controlinformesnutricion WHERE ficha = sa.id AND controlado = 0) ")
        sql.Append("OR EXISTS (SELECT 1 FROM controlinformessuelos WHERE ficha = sa.id AND controlado = 0)) ")
        sql.Append("AND sa.FECHAENVIO <= CURDATE() ")

        sql.Append("ORDER BY fechaingreso DESC")

        Try
            Dim lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql.ToString())

            For Each fila As DataRow In Ds.Tables(0).Rows
                Dim i As New dInformeGestor
                i.FICHA = CType(fila.Item("ficha"), Long)
                i.FECHAINGRESO = CType(fila.Item("fechaingreso"), String)
                i.FECHAENVIO = CType(fila.Item("fechaenvio"), String)  ' Aquí la nueva propiedad
                i.CLIENTE = CType(fila.Item("cliente"), String)
                i.TIPOINFORME = CType(fila.Item("tipoinforme"), String)
                i.ESTADO = CType(fila.Item("estado"), String)
                lista.Add(i)
            Next
            Return lista
        Catch ex As Exception
            Return Nothing
        End Try
    End Function




    Public Function listarparasubircontrol() As ArrayList
        Dim sql As String = "SELECT id, ficha, tipo, creado, abonado, ifnull(comentario,''),ifnull(copia,''), parasubir, subido, fecha, control FROM preinformes WHERE tipo = 1 AND parasubir =1 AND subido = 0"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dPreinformes
                    p.ID = CType(unaFila.Item(0), Long)
                    p.FICHA = CType(unaFila.Item(1), Long)
                    p.TIPO = CType(unaFila.Item(2), Integer)
                    p.CREADO = CType(unaFila.Item(3), Integer)
                    p.ABONADO = CType(unaFila.Item(4), Integer)
                    p.COMENTARIO = CType(unaFila.Item(5), String)
                    p.COPIA = CType(unaFila.Item(6), String)
                    p.PARASUBIR = CType(unaFila.Item(7), Integer)
                    p.SUBIDO = CType(unaFila.Item(8), Integer)
                    p.FECHA = CType(unaFila.Item(9), String)
                    p.CONTROL = CType(unaFila.Item(10), Integer)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarparasubiragua() As ArrayList
        Dim sql As String = "SELECT id, ficha, tipo, creado, abonado, ifnull(comentario,''),ifnull(copia,''), parasubir, subido, fecha, control FROM preinformes WHERE tipo = 3 AND parasubir =1 AND subido = 0"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dPreinformes
                    p.ID = CType(unaFila.Item(0), Long)
                    p.FICHA = CType(unaFila.Item(1), Long)
                    p.TIPO = CType(unaFila.Item(2), Integer)
                    p.CREADO = CType(unaFila.Item(3), Integer)
                    p.ABONADO = CType(unaFila.Item(4), Integer)
                    p.COMENTARIO = CType(unaFila.Item(5), String)
                    p.COPIA = CType(unaFila.Item(6), String)
                    p.PARASUBIR = CType(unaFila.Item(7), Integer)
                    p.SUBIDO = CType(unaFila.Item(8), Integer)
                    p.FECHA = CType(unaFila.Item(9), String)
                    p.CONTROL = CType(unaFila.Item(10), Integer)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarparasubiratb() As ArrayList
        Dim sql As String = "SELECT id, ficha, tipo, creado, abonado, ifnull(comentario,''),ifnull(copia,''), parasubir, subido, fecha, control FROM preinformes WHERE tipo = 4 AND parasubir =1 AND subido = 0"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dPreinformes
                    p.ID = CType(unaFila.Item(0), Long)
                    p.FICHA = CType(unaFila.Item(1), Long)
                    p.TIPO = CType(unaFila.Item(2), Integer)
                    p.CREADO = CType(unaFila.Item(3), Integer)
                    p.ABONADO = CType(unaFila.Item(4), Integer)
                    p.COMENTARIO = CType(unaFila.Item(5), String)
                    p.COPIA = CType(unaFila.Item(6), String)
                    p.PARASUBIR = CType(unaFila.Item(7), Integer)
                    p.SUBIDO = CType(unaFila.Item(8), Integer)
                    p.FECHA = CType(unaFila.Item(9), String)
                    p.CONTROL = CType(unaFila.Item(10), Integer)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarparasubirsubproductos() As ArrayList
        Dim sql As String = "SELECT id, ficha, tipo, creado, abonado, ifnull(comentario,''),ifnull(copia,''), parasubir, subido, fecha, control FROM preinformes WHERE tipo = 7 AND parasubir =1 AND subido = 0"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dPreinformes
                    p.ID = CType(unaFila.Item(0), Long)
                    p.FICHA = CType(unaFila.Item(1), Long)
                    p.TIPO = CType(unaFila.Item(2), Integer)
                    p.CREADO = CType(unaFila.Item(3), Integer)
                    p.ABONADO = CType(unaFila.Item(4), Integer)
                    p.COMENTARIO = CType(unaFila.Item(5), String)
                    p.COPIA = CType(unaFila.Item(6), String)
                    p.PARASUBIR = CType(unaFila.Item(7), Integer)
                    p.SUBIDO = CType(unaFila.Item(8), Integer)
                    p.FECHA = CType(unaFila.Item(9), String)
                    p.CONTROL = CType(unaFila.Item(10), Integer)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarparasubircalidad() As ArrayList
        Dim sql As String = "SELECT id, ficha, tipo, creado, abonado, ifnull(comentario,''),ifnull(copia,''), parasubir, subido, fecha, control FROM preinformes WHERE tipo = 10 AND parasubir =1 AND subido = 0"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dPreinformes
                    p.ID = CType(unaFila.Item(0), Long)
                    p.FICHA = CType(unaFila.Item(1), Long)
                    p.TIPO = CType(unaFila.Item(2), Integer)
                    p.CREADO = CType(unaFila.Item(3), Integer)
                    p.ABONADO = CType(unaFila.Item(4), Integer)
                    p.COMENTARIO = CType(unaFila.Item(5), String)
                    p.COPIA = CType(unaFila.Item(6), String)
                    p.PARASUBIR = CType(unaFila.Item(7), Integer)
                    p.SUBIDO = CType(unaFila.Item(8), Integer)
                    p.FECHA = CType(unaFila.Item(9), String)
                    p.CONTROL = CType(unaFila.Item(10), Integer)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarparasubirbrucelosis() As ArrayList
        Dim sql As String = "SELECT id, ficha, tipo, creado, abonado, ifnull(comentario,''),ifnull(copia,''), parasubir, subido, fecha, control FROM preinformes WHERE tipo = 15 AND parasubir =1 AND subido = 0"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dPreinformes
                    p.ID = CType(unaFila.Item(0), Long)
                    p.FICHA = CType(unaFila.Item(1), Long)
                    p.TIPO = CType(unaFila.Item(2), Integer)
                    p.CREADO = CType(unaFila.Item(3), Integer)
                    p.ABONADO = CType(unaFila.Item(4), Integer)
                    p.COMENTARIO = CType(unaFila.Item(5), String)
                    p.COPIA = CType(unaFila.Item(6), String)
                    p.PARASUBIR = CType(unaFila.Item(7), Integer)
                    p.SUBIDO = CType(unaFila.Item(8), Integer)
                    p.FECHA = CType(unaFila.Item(9), String)
                    p.CONTROL = CType(unaFila.Item(10), Integer)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarparasubirmicro() As ArrayList
        Dim sql As String = "SELECT id, ficha, tipo, creado, abonado, ifnull(comentario,''),ifnull(copia,''), parasubir, subido, fecha, control FROM preinformes WHERE tipo = 3 OR tipo = 7 OR tipo = 10 AND parasubir =1 AND subido = 0"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dPreinformes
                    p.ID = CType(unaFila.Item(0), Long)
                    p.FICHA = CType(unaFila.Item(1), Long)
                    p.TIPO = CType(unaFila.Item(2), Integer)
                    p.CREADO = CType(unaFila.Item(3), Integer)
                    p.ABONADO = CType(unaFila.Item(4), Integer)
                    p.COMENTARIO = CType(unaFila.Item(5), String)
                    p.COPIA = CType(unaFila.Item(6), String)
                    p.PARASUBIR = CType(unaFila.Item(7), Integer)
                    p.SUBIDO = CType(unaFila.Item(8), Integer)
                    p.FECHA = CType(unaFila.Item(9), String)
                    p.CONTROL = CType(unaFila.Item(10), Integer)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarsubidas() As ArrayList
        Dim sql As String = "SELECT id, ficha, tipo, creado, abonado, ifnull(comentario,''),ifnull(copia,''), parasubir, subido, fecha, control FROM preinformes WHERE parasubir =1 AND subido = 1 ORDER BY FECHA DESC LIMIT 100"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dPreinformes
                    p.ID = CType(unaFila.Item(0), Long)
                    p.FICHA = CType(unaFila.Item(1), Long)
                    p.TIPO = CType(unaFila.Item(2), Integer)
                    p.CREADO = CType(unaFila.Item(3), Integer)
                    p.ABONADO = CType(unaFila.Item(4), Integer)
                    p.COMENTARIO = CType(unaFila.Item(5), String)
                    p.COPIA = CType(unaFila.Item(6), String)
                    p.PARASUBIR = CType(unaFila.Item(7), Integer)
                    p.SUBIDO = CType(unaFila.Item(8), Integer)
                    p.FECHA = CType(unaFila.Item(9), String)
                    p.CONTROL = CType(unaFila.Item(10), Integer)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function buscarPorId(ByVal ficha As Integer) As dPreinformes
        Dim sql As String = "SELECT id, ficha, tipo, creado, abonado, ifnull(comentario,''),ifnull(copia,''), parasubir, subido, fecha, control FROM preinformes WHERE ficha = " & ficha & " "
        Try
            Dim p As New dPreinformes
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows

                    p.ID = CType(unaFila.Item(0), Long)
                    p.FICHA = CType(unaFila.Item(1), Long)
                    p.TIPO = CType(unaFila.Item(2), Integer)
                    p.CREADO = CType(unaFila.Item(3), Integer)
                    p.ABONADO = CType(unaFila.Item(4), Integer)
                    p.COMENTARIO = CType(unaFila.Item(5), String)
                    p.COPIA = CType(unaFila.Item(6), String)
                    p.PARASUBIR = CType(unaFila.Item(7), Integer)
                    p.SUBIDO = CType(unaFila.Item(8), Integer)
                    p.FECHA = CType(unaFila.Item(9), String)
                    p.CONTROL = CType(unaFila.Item(10), Integer)

                Next
                Return p
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function ListaControlCalidad() As ArrayList
        Dim sql As String = "SELECT id, ficha, tipo, creado, abonado, ifnull(comentario,''),ifnull(copia,''), parasubir, subido, fecha, control FROM preinformes WHERE tipo in(1,10) and subido = 0 ORDER BY FICHA DESC "
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dPreinformes
                    p.ID = CType(unaFila.Item(0), Long)
                    p.FICHA = CType(unaFila.Item(1), Long)
                    p.TIPO = CType(unaFila.Item(2), Integer)
                    p.CREADO = CType(unaFila.Item(3), Integer)
                    p.ABONADO = CType(unaFila.Item(4), Integer)
                    p.COMENTARIO = CType(unaFila.Item(5), String)
                    p.COPIA = CType(unaFila.Item(6), String)
                    p.PARASUBIR = CType(unaFila.Item(7), Integer)
                    p.SUBIDO = CType(unaFila.Item(8), Integer)
                    p.FECHA = CType(unaFila.Item(9), String)
                    p.CONTROL = CType(unaFila.Item(10), Integer)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function ModificarPreinforme(ByVal idTI As Integer, ByVal ficha As Integer) As Boolean

        Dim sql As String = "UPDATE preinformes SET creado= 0, tipo =" & idTI & " WHERE ficha = " & ficha & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Return EjecutarTransaccion(lista)
    End Function

End Class
