Public Class pDetalleMuestreo
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dDetalleMuestreo = CType(o, dDetalleMuestreo)
        Dim sql As String = "INSERT INTO detalle_muestreo (id, ficha, fecha, observaciones) VALUES (" & obj.ID & ", " & obj.FICHA & ", '" & obj.FECHA & "', '" & obj.OBSERVACIONES & "')"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'envio_muestra', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dDetalleMuestreo = CType(o, dDetalleMuestreo)
        Dim sql As String = "UPDATE detalle_muestreo SET ficha = " & obj.FICHA & ", fecha = '" & obj.FECHA & "', observaciones = '" & obj.OBSERVACIONES & "' WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'envio_muestra', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dDetalleMuestreo = CType(o, dDetalleMuestreo)
        Dim sql As String = "DELETE FROM detalle_muestreo WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'envio_muestra', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dDetalleMuestreo
        Dim obj As dDetalleMuestreo = CType(o, dDetalleMuestreo)
        Dim m As New dDetalleMuestreo
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, ficha, fecha, observaciones FROM detalle_muestreo WHERE ficha = " & obj.FICHA & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                m.ID = CType(unaFila.Item(0), Long)
                m.FICHA = CType(unaFila.Item(1), Long)
                m.FECHA = CType(unaFila.Item(2), String)
                m.OBSERVACIONES = CType(unaFila.Item(3), String)
                Return m
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscarultimo(ByVal o As Object) As dDetalleMuestreo
        Dim obj As dDetalleMuestreo = CType(o, dDetalleMuestreo)
        Dim m As New dDetalleMuestreo
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, ficha, fecha, observaciones FROM detalle_muestreo ORDER By id DESC LIMIT 1 ")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                  m.ID = CType(unaFila.Item(0), Long)
                m.FICHA = CType(unaFila.Item(1), Long)
                m.FECHA = CType(unaFila.Item(2), String)
                m.OBSERVACIONES = CType(unaFila.Item(3), String)
                Return m
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, ficha, fecha, observaciones FROM detalle_muestreo ORDER BY id ASC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim m As New dDetalleMuestreo
                      m.ID = CType(unaFila.Item(0), Long)
                    m.FICHA = CType(unaFila.Item(1), Long)
                    m.FECHA = CType(unaFila.Item(2), String)
                    m.OBSERVACIONES = CType(unaFila.Item(3), String)
                    Lista.Add(m)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
