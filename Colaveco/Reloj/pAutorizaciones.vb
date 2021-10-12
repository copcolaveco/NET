Public Class pAutorizaciones
    Inherits Conectoras.ConexionMySQL_reloj
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dAutorizaciones = CType(o, dAutorizaciones)
        Dim sql As String = "INSERT INTO autorizaciones (id, fecha, idusuario, tipo, fechaevento, detalle, autoriza, observaciones, autorizada, email) VALUES (" & obj.ID & ", '" & obj.FECHA & "', " & obj.IDUSUARIO & ", " & obj.TIPO & ",'" & obj.FECHAEVENTO & "','" & obj.DETALLE & "', " & obj.AUTORIZA & ",'" & obj.OBSERVACIONES & "',  " & obj.AUTORIZADA & ",  '" & obj.EMAIL & "')"

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dAutorizaciones = CType(o, dAutorizaciones)
        Dim sql As String = "UPDATE autorizaciones SET fecha= '" & obj.FECHA & "', idusuario = " & obj.IDUSUARIO & ", tipo = " & obj.TIPO & ", fechaevento= '" & obj.FECHAEVENTO & "',detalle = '" & obj.DETALLE & "', autoriza = " & obj.AUTORIZA & ", observaciones = '" & obj.OBSERVACIONES & "', autorizada = " & obj.AUTORIZADA & ", email = '" & obj.EMAIL & "' WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)



        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dAutorizaciones = CType(o, dAutorizaciones)
        Dim sql As String = "DELETE FROM autorizaciones WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dAutorizaciones
        Dim obj As dAutorizaciones = CType(o, dAutorizaciones)
        Dim l As New dAutorizaciones
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, fecha, idusuario, tipo, fechaevento, detalle, autoriza, observaciones, autorizada, email FROM autorizaciones WHERE id = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                l.ID = CType(unaFila.Item(0), Long)
                l.FECHA = CType(unaFila.Item(1), String)
                l.IDUSUARIO = CType(unaFila.Item(2), Integer)
                l.TIPO = CType(unaFila.Item(3), Integer)
                l.FECHAEVENTO = CType(unaFila.Item(4), String)
                l.DETALLE = CType(unaFila.Item(5), String)
                l.AUTORIZA = CType(unaFila.Item(6), Integer)
                l.OBSERVACIONES = CType(unaFila.Item(7), String)
                l.AUTORIZADA = CType(unaFila.Item(8), Integer)
                l.EMAIL = CType(unaFila.Item(9), String)
                Return l
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function marcarautorizada(ByVal o As Object) As Boolean
        Dim obj As dAutorizaciones = CType(o, dAutorizaciones)
        Dim sql As String = "UPDATE autorizaciones SET autorizada = 1 WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)



        Return EjecutarTransaccion(lista)
    End Function
    Public Function desmarcarautorizada(ByVal o As Object) As Boolean
        Dim obj As dAutorizaciones = CType(o, dAutorizaciones)
        Dim sql As String = "UPDATE autorizaciones SET autorizada = 0 WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)



        Return EjecutarTransaccion(lista)
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, fecha, idusuario, tipo, fechaevento, detalle, autoriza, observaciones, autorizada, email FROM autorizaciones ORDER BY fecha DESC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dAutorizaciones
                    l.ID = CType(unaFila.Item(0), Long)
                    l.FECHA = CType(unaFila.Item(1), String)
                    l.IDUSUARIO = CType(unaFila.Item(2), Integer)
                    l.TIPO = CType(unaFila.Item(3), Integer)
                    l.FECHAEVENTO = CType(unaFila.Item(4), String)
                    l.DETALLE = CType(unaFila.Item(5), String)
                    l.AUTORIZA = CType(unaFila.Item(6), Integer)
                    l.OBSERVACIONES = CType(unaFila.Item(7), String)
                    l.AUTORIZADA = CType(unaFila.Item(8), Integer)
                    l.EMAIL = CType(unaFila.Item(9), String)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxusuarioxfecha(ByVal usu As Integer, ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim sql As String = "SELECT id, fecha, idusuario, tipo, fechaevento, detalle, autoriza, observaciones, autorizada, email FROM autorizaciones Where autorizada =1 AND idusuario = " & usu & " and fechaevento BETWEEN '" & desde & "' and '" & hasta & "' ORDER BY fecha asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dAutorizaciones
                    l.ID = CType(unaFila.Item(0), Long)
                    l.FECHA = CType(unaFila.Item(1), String)
                    l.IDUSUARIO = CType(unaFila.Item(2), Integer)
                    l.TIPO = CType(unaFila.Item(3), Integer)
                    l.FECHAEVENTO = CType(unaFila.Item(4), String)
                    l.DETALLE = CType(unaFila.Item(5), String)
                    l.AUTORIZA = CType(unaFila.Item(6), Integer)
                    l.OBSERVACIONES = CType(unaFila.Item(7), String)
                    l.AUTORIZADA = CType(unaFila.Item(8), Integer)
                    l.EMAIL = CType(unaFila.Item(9), String)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarsinautorizar() As ArrayList
        Dim sql As String = "SELECT id, fecha, idusuario, tipo, fechaevento, detalle, autoriza, observaciones, autorizada, email FROM autorizaciones WHERE autorizada = 0 ORDER BY fecha DESC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dAutorizaciones
                    l.ID = CType(unaFila.Item(0), Long)
                    l.FECHA = CType(unaFila.Item(1), String)
                    l.IDUSUARIO = CType(unaFila.Item(2), Integer)
                    l.TIPO = CType(unaFila.Item(3), Integer)
                    l.FECHAEVENTO = CType(unaFila.Item(4), String)
                    l.DETALLE = CType(unaFila.Item(5), String)
                    l.AUTORIZA = CType(unaFila.Item(6), Integer)
                    l.OBSERVACIONES = CType(unaFila.Item(7), String)
                    l.AUTORIZADA = CType(unaFila.Item(8), Integer)
                    l.EMAIL = CType(unaFila.Item(9), String)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarultimos50() As ArrayList
        Dim sql As String = "SELECT id, fecha, idusuario, tipo, fechaevento, detalle, autoriza, observaciones, autorizada, email FROM autorizaciones ORDER BY  fechaevento DESC LIMIT 50"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dAutorizaciones
                    l.ID = CType(unaFila.Item(0), Long)
                    l.FECHA = CType(unaFila.Item(1), String)
                    l.IDUSUARIO = CType(unaFila.Item(2), Integer)
                    l.TIPO = CType(unaFila.Item(3), Integer)
                    l.FECHAEVENTO = CType(unaFila.Item(4), String)
                    l.DETALLE = CType(unaFila.Item(5), String)
                    l.AUTORIZA = CType(unaFila.Item(6), Integer)
                    l.OBSERVACIONES = CType(unaFila.Item(7), String)
                    l.AUTORIZADA = CType(unaFila.Item(8), Integer)
                    l.EMAIL = CType(unaFila.Item(9), String)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarsemana(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim sql As String = "SELECT id, fecha, idusuario, tipo, fechaevento, detalle, autoriza, observaciones, autorizada, email FROM autorizaciones WHERE fechaevento BETWEEN '" & desde & "' and '" & hasta & "' ORDER BY  fechaevento DESC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dAutorizaciones
                    l.ID = CType(unaFila.Item(0), Long)
                    l.FECHA = CType(unaFila.Item(1), String)
                    l.IDUSUARIO = CType(unaFila.Item(2), Integer)
                    l.TIPO = CType(unaFila.Item(3), Integer)
                    l.FECHAEVENTO = CType(unaFila.Item(4), String)
                    l.DETALLE = CType(unaFila.Item(5), String)
                    l.AUTORIZA = CType(unaFila.Item(6), Integer)
                    l.OBSERVACIONES = CType(unaFila.Item(7), String)
                    l.AUTORIZADA = CType(unaFila.Item(8), Integer)
                    l.EMAIL = CType(unaFila.Item(9), String)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxano(ByVal ano As Integer) As ArrayList
        Dim sql As String = "SELECT id, fecha, idusuario, tipo, fechaevento, detalle, autoriza, observaciones, autorizada, email FROM autorizaciones WHERE year(desde) = " & ano & " AND year(hasta) = " & ano & " ORDER BY desde ASC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dAutorizaciones
                    l.ID = CType(unaFila.Item(0), Long)
                    l.FECHA = CType(unaFila.Item(1), String)
                    l.IDUSUARIO = CType(unaFila.Item(2), Integer)
                    l.TIPO = CType(unaFila.Item(3), Integer)
                    l.FECHAEVENTO = CType(unaFila.Item(4), String)
                    l.DETALLE = CType(unaFila.Item(5), String)
                    l.AUTORIZA = CType(unaFila.Item(6), Integer)
                    l.OBSERVACIONES = CType(unaFila.Item(7), String)
                    l.AUTORIZADA = CType(unaFila.Item(8), Integer)
                    l.EMAIL = CType(unaFila.Item(9), String)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxanoxusuario(ByVal ano As Integer, ByVal idusuario As Integer) As ArrayList
        Dim sql As String = "SELECT id, fecha, idusuario, tipo, fechaevento, detalle, autoriza, observaciones, autorizada, email FROM autorizaciones WHERE year(desde) = " & ano & " AND idusuario = " & idusuario & " ORDER BY desde ASC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dAutorizaciones
                    l.ID = CType(unaFila.Item(0), Long)
                    l.FECHA = CType(unaFila.Item(1), String)
                    l.IDUSUARIO = CType(unaFila.Item(2), Integer)
                    l.TIPO = CType(unaFila.Item(3), Integer)
                    l.FECHAEVENTO = CType(unaFila.Item(4), String)
                    l.DETALLE = CType(unaFila.Item(5), String)
                    l.AUTORIZA = CType(unaFila.Item(6), Integer)
                    l.OBSERVACIONES = CType(unaFila.Item(7), String)
                    l.AUTORIZADA = CType(unaFila.Item(8), Integer)
                    l.EMAIL = CType(unaFila.Item(9), String)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxusuario(ByVal idusuario As Integer, ByVal ano As Integer) As ArrayList
        Dim sql As String = "SELECT id, fecha, idusuario, tipo, fechaevento, detalle, autoriza, observaciones, autorizada, email FROM autorizaciones WHERE idusuario= " & idusuario & " AND year(desde) = " & ano & " AND year(hasta) = " & ano & " ORDER BY desde ASC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dAutorizaciones
                    l.ID = CType(unaFila.Item(0), Long)
                    l.FECHA = CType(unaFila.Item(1), String)
                    l.IDUSUARIO = CType(unaFila.Item(2), Integer)
                    l.TIPO = CType(unaFila.Item(3), Integer)
                    l.FECHAEVENTO = CType(unaFila.Item(4), String)
                    l.DETALLE = CType(unaFila.Item(5), String)
                    l.AUTORIZA = CType(unaFila.Item(6), Integer)
                    l.OBSERVACIONES = CType(unaFila.Item(7), String)
                    l.AUTORIZADA = CType(unaFila.Item(8), Integer)
                    l.EMAIL = CType(unaFila.Item(9), String)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
