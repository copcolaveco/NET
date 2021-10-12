Public Class pSaldos
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dSaldos = CType(o, dSaldos)
        Dim sql As String = "INSERT INTO saldos (idcliente, saldo) VALUES (" & obj.IDCLIENTE & ", " & obj.SALDO & ")"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'saldos', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dSaldos = CType(o, dSaldos)
        Dim sql As String = "UPDATE saldos SET saldo = " & obj.SALDO & " WHERE idcliente = " & obj.IDCLIENTE & ""

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dSaldos = CType(o, dSaldos)
        Dim sql As String = "DELETE FROM saldos WHERE id = " & obj.IDCLIENTE & ""

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminartodos(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dSaldos = CType(o, dSaldos)
        Dim sql As String = "TRUNCATE TABLE saldos "

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dSaldos
        Dim obj As dSaldos = CType(o, dSaldos)
        Dim l As New dSaldos
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT idcliente, saldo FROM saldos WHERE idcliente = " & obj.IDCLIENTE & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                l.IDCLIENTE = CType(unaFila.Item(0), Long)
                l.SALDO = CType(unaFila.Item(1), Double)
                Return l
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT idcliente, saldo FROM saldos"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dSaldos
                    l.IDCLIENTE = CType(unaFila.Item(0), Long)
                    l.SALDO = CType(unaFila.Item(1), Double)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
