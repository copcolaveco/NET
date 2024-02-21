Public Class pRelSolicitudCajas
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dRelSolicitudCajas = CType(o, dRelSolicitudCajas)
        Dim sql As String = "INSERT INTO solicitud_cajas (id, ficha, idenvio, idcaja, gradilla1, gradilla2, gradilla3, frascos, nocolaveco, eliminado) VALUES (" & obj.ID & ", " & obj.FICHA & "," & obj.IDENVIO & ", '" & obj.IDCAJA & "', " & obj.GRADILLA1 & "," & obj.GRADILLA2 & "," & obj.GRADILLA3 & "," & obj.FRASCOS & ", " & obj.NOCOLAVECO & ", " & obj.ELIMINADO & ")"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'solicitud_cajas', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dRelSolicitudCajas = CType(o, dRelSolicitudCajas)
        Dim sql As String = "UPDATE solicitud_cajas SET ficha =" & obj.FICHA & ",idenvio =" & obj.IDENVIO & ", idcaja ='" & obj.IDCAJA & "',gradilla1 =" & obj.GRADILLA1 & ",gradilla2 =" & obj.GRADILLA2 & ",gradilla3=" & obj.GRADILLA3 & ",frascos =" & obj.FRASCOS & ", nocolaveco=" & obj.NOCOLAVECO & ", eliminado=" & obj.ELIMINADO & " WHERE ID = " & obj.ID

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'solicitud_cajas', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dRelSolicitudCajas = CType(o, dRelSolicitudCajas)
        Dim sql As String = "UPDATE solicitud_cajas SET eliminado = 1 WHERE ID = " & obj.ID

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'solicitud_cajas', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminarPorIdCaja(ByVal o As Object, ByVal idCaja As String) As Boolean
        Dim obj As dRelSolicitudCajas = CType(o, dRelSolicitudCajas)
        Dim sql As String = "UPDATE solicitud_cajas SET eliminado = 1 WHERE IDCAJA = '" & idCaja & "'"

        Dim lista As New ArrayList
        lista.Add(sql)

        'Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
        '& "VALUES (now(), 'solicitud_cajas', 'eliminación', " & obj.ID & ", " & idCaja & ")"
        'lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dRelSolicitudCajas
        Dim obj As dRelSolicitudCajas = CType(o, dRelSolicitudCajas)
        Dim e As New dRelSolicitudCajas
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, ficha, idenvio, idcaja, gradilla1, gradilla2,gradilla3, frascos, nocolaveco, eliminado FROM solicitud_cajas WHERE ficha = " & obj.ficha)

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                e.ID = CType(unaFila.Item(0), Long)
                e.ficha = CType(unaFila.Item(1), Long)
                e.IDENVIO = CType(unaFila.Item(2), Long)
                e.IDCAJA = CType(unaFila.Item(3), String)
                e.GRADILLA1 = CType(unaFila.Item(4), Integer)
                e.GRADILLA2 = CType(unaFila.Item(5), Integer)
                e.GRADILLA3 = CType(unaFila.Item(6), Integer)
                e.FRASCOS = CType(unaFila.Item(7), Integer)
                e.NOCOLAVECO = CType(unaFila.Item(8), Integer)
                e.ELIMINADO = CType(unaFila.Item(9), Integer)
                Return e
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, ficha, idenvio, idcaja, gradilla1, gradilla2, gradilla3, frascos FROM enviocajas WHERE eliminado = 0 order by id desc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim e As New dRelSolicitudCajas
                    e.ID = CType(unaFila.Item(0), Long)
                    e.ficha = CType(unaFila.Item(1), Long)
                    e.IDENVIO = CType(unaFila.Item(2), Long)
                    e.IDCAJA = CType(unaFila.Item(3), String)
                    e.GRADILLA1 = CType(unaFila.Item(4), Integer)
                    e.GRADILLA2 = CType(unaFila.Item(5), Integer)
                    e.GRADILLA3 = CType(unaFila.Item(6), Integer)
                    e.FRASCOS = CType(unaFila.Item(7), Integer)
                    e.NOCOLAVECO = CType(unaFila.Item(8), Integer)
                    e.ELIMINADO = CType(unaFila.Item(9), Integer)
                    Lista.Add(e)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    
    Public Function listarporid(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, ficha, idenvio, idcaja, gradilla1, gradilla2, gradilla3,frascos, nocolaveco, eliminado FROM solicitud_cajas WHERE eliminado = 0 AND ficha = " & texto & "")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim e As New dRelSolicitudCajas
                    e.ID = CType(unaFila.Item(0), Long)
                    e.ficha = CType(unaFila.Item(1), Long)
                    e.IDENVIO = CType(unaFila.Item(2), Long)
                    e.IDCAJA = CType(unaFila.Item(3), String)
                    e.GRADILLA1 = CType(unaFila.Item(4), Integer)
                    e.GRADILLA2 = CType(unaFila.Item(5), Integer)
                    e.GRADILLA3 = CType(unaFila.Item(6), Integer)
                    e.FRASCOS = CType(unaFila.Item(7), Integer)
                    e.NOCOLAVECO = CType(unaFila.Item(8), Integer)
                    e.ELIMINADO = CType(unaFila.Item(9), Integer)
                    Lista.Add(e)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarporficha(ByVal ficha As String) As ArrayList
        Dim sql As String = ("SELECT id, ficha, idenvio, idcaja, gradilla1, gradilla2, gradilla3,frascos, nocolaveco, eliminado FROM solicitud_cajas WHERE eliminado = 0 AND ficha = " & ficha & "")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim e As New dRelSolicitudCajas
                    e.ID = CType(unaFila.Item(0), Long)
                    e.ficha = CType(unaFila.Item(1), Long)
                    e.IDENVIO = CType(unaFila.Item(2), Long)
                    e.IDCAJA = CType(unaFila.Item(3), String)
                    e.GRADILLA1 = CType(unaFila.Item(4), Integer)
                    e.GRADILLA2 = CType(unaFila.Item(5), Integer)
                    e.GRADILLA3 = CType(unaFila.Item(6), Integer)
                    e.FRASCOS = CType(unaFila.Item(7), Integer)
                    e.NOCOLAVECO = CType(unaFila.Item(8), Integer)
                    e.ELIMINADO = CType(unaFila.Item(9), Integer)
                    Lista.Add(e)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    End Class
