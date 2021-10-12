Public Class pObjGral
    Inherits Conectoras.ConexionMySQL_CMI
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dObjGral = CType(o, dObjGral)
        Dim sql As String = "INSERT INTO objgral (id, iddimension, nombre, ano) VALUES (" & obj.ID & ", " & obj.IDDIMENSION & ", '" & obj.NOMBRE & "', " & obj.ANO & ")"

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dObjGral = CType(o, dObjGral)
        Dim sql As String = "UPDATE objgral SET iddimension = " & obj.IDDIMENSION & ",nombre = '" & obj.NOMBRE & "',ano = " & obj.ANO & " WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dObjGral = CType(o, dObjGral)
        Dim sql As String = "DELETE FROM objgral WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dObjGral
        Dim obj As dObjGral = CType(o, dObjGral)
        Dim og As New dObjGral
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, iddimension, nombre, ano FROM objgral WHERE id = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                og.ID = CType(unaFila.Item(0), Long)
                og.IDDIMENSION = CType(unaFila.Item(1), Long)
                og.NOMBRE = CType(unaFila.Item(2), String)
                og.ANO = CType(unaFila.Item(3), Integer)
                Return og
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscarxiddimension(ByVal o As Object) As dObjGral
        Dim obj As dObjGral = CType(o, dObjGral)
        Dim og As New dObjGral
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, iddimension, nombre, ano FROM objgral WHERE iddimension = " & obj.IDDIMENSION & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                og.ID = CType(unaFila.Item(0), Long)
                og.IDDIMENSION = CType(unaFila.Item(1), Long)
                og.NOMBRE = CType(unaFila.Item(2), String)
                og.ANO = CType(unaFila.Item(3), Integer)
                Return og
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, iddimension, nombre, ano FROM objgral ORDER BY nombre ASC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim og As New dObjGral
                    og.ID = CType(unaFila.Item(0), Long)
                    og.IDDIMENSION = CType(unaFila.Item(1), Long)
                    og.NOMBRE = CType(unaFila.Item(2), String)
                    og.ANO = CType(unaFila.Item(3), Integer)
                    Lista.Add(og)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxano(ByVal ano As Integer) As ArrayList
        Dim sql As String = "SELECT id, iddimension, nombre, ano FROM objgral WHERE ano = " & ano & "  "
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim og As New dObjGral
                    og.ID = CType(unaFila.Item(0), Long)
                    og.IDDIMENSION = CType(unaFila.Item(1), Long)
                    og.NOMBRE = CType(unaFila.Item(2), String)
                    og.ANO = CType(unaFila.Item(3), Integer)
                    Lista.Add(og)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxdimension(ByVal iddimension As Long) As ArrayList
        Dim sql As String = "SELECT id, iddimension, nombre, ano FROM objgral WHERE iddimension = " & iddimension & "  "
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim og As New dObjGral
                    og.ID = CType(unaFila.Item(0), Long)
                    og.IDDIMENSION = CType(unaFila.Item(1), Long)
                    og.NOMBRE = CType(unaFila.Item(2), String)
                    og.ANO = CType(unaFila.Item(3), Integer)
                    Lista.Add(og)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
