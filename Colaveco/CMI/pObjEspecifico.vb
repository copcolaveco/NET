Public Class pObjEspecifico
    Inherits Conectoras.ConexionMySQL_CMI
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dObjEspecifico = CType(o, dObjEspecifico)
        Dim sql As String = "INSERT INTO objespecifico (id, iddimension, idobjgral, nombre, ano) VALUES (" & obj.ID & ", " & obj.IDDIMENSION & "," & obj.IDOBJGRAL & ", '" & obj.NOMBRE & "', " & obj.ANO & ")"

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dObjEspecifico = CType(o, dObjEspecifico)
        Dim sql As String = "UPDATE objespecifico SET iddimension = " & obj.IDDIMENSION & ",idobjgral = " & obj.IDOBJGRAL & ",nombre = '" & obj.NOMBRE & "',ano = " & obj.ANO & " WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dObjEspecifico = CType(o, dObjEspecifico)
        Dim sql As String = "DELETE FROM objespecifico WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dObjEspecifico
        Dim obj As dObjEspecifico = CType(o, dObjEspecifico)
        Dim oe As New dObjEspecifico
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, iddimension, idobjgral, nombre, ano FROM objespecifico WHERE id = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                oe.ID = CType(unaFila.Item(0), Long)
                oe.IDDIMENSION = CType(unaFila.Item(1), Long)
                oe.IDOBJGRAL = CType(unaFila.Item(2), Long)
                oe.NOMBRE = CType(unaFila.Item(3), String)
                oe.ANO = CType(unaFila.Item(4), Integer)
                Return oe
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, iddimension, idobjgral, nombre, ano FROM objespecifico ORDER BY ano DESC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim oe As New dObjEspecifico
                    oe.ID = CType(unaFila.Item(0), Long)
                    oe.IDDIMENSION = CType(unaFila.Item(1), Long)
                    oe.IDOBJGRAL = CType(unaFila.Item(2), Long)
                    oe.NOMBRE = CType(unaFila.Item(3), String)
                    oe.ANO = CType(unaFila.Item(4), Integer)
                    Lista.Add(oe)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxano(ByVal ano As Integer) As ArrayList
        Dim sql As String = "SELECT id, iddimension, idobjgral, nombre, ano FROM objespecifico WHERE ano= " & ano & ""
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim oe As New dObjEspecifico
                    oe.ID = CType(unaFila.Item(0), Long)
                    oe.IDDIMENSION = CType(unaFila.Item(1), Long)
                    oe.IDOBJGRAL = CType(unaFila.Item(2), Long)
                    oe.NOMBRE = CType(unaFila.Item(3), String)
                    oe.ANO = CType(unaFila.Item(4), Integer)
                    Lista.Add(oe)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxobjgral(ByVal idobjgral As Long) As ArrayList
        Dim sql As String = "SELECT id, iddimension, idobjgral, nombre, ano FROM objespecifico WHERE idobjgral= " & idobjgral & ""
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim oe As New dObjEspecifico
                    oe.ID = CType(unaFila.Item(0), Long)
                    oe.IDDIMENSION = CType(unaFila.Item(1), Long)
                    oe.IDOBJGRAL = CType(unaFila.Item(2), Long)
                    oe.NOMBRE = CType(unaFila.Item(3), String)
                    oe.ANO = CType(unaFila.Item(4), Integer)
                    Lista.Add(oe)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxdimension(ByVal iddimension As Long) As ArrayList
        Dim sql As String = "SELECT id, iddimension, idobjgral, nombre, ano FROM objespecifico WHERE iddimension= " & iddimension & ""
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim oe As New dObjEspecifico
                    oe.ID = CType(unaFila.Item(0), Long)
                    oe.IDDIMENSION = CType(unaFila.Item(1), Long)
                    oe.IDOBJGRAL = CType(unaFila.Item(2), Long)
                    oe.NOMBRE = CType(unaFila.Item(3), String)
                    oe.ANO = CType(unaFila.Item(4), Integer)
                    Lista.Add(oe)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
