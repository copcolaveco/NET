Public Class pLicenciaAnual
    Inherits Conectoras.ConexionMySQL_reloj
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dLicenciaAnual = CType(o, dLicenciaAnual)
        Dim sql As String = "INSERT INTO licenciaanual (id, funcionario, dias, ano) VALUES (" & obj.ID & ", " & obj.FUNCIONARIO & ", " & obj.DIAS & ", " & obj.ANO & ")"

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dLicenciaAnual = CType(o, dLicenciaAnual)
        Dim sql As String = "UPDATE licenciaanual SET funcionario = " & obj.FUNCIONARIO & ", dias = " & obj.DIAS & ", ano = " & obj.ANO & " WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)



        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dLicenciaAnual = CType(o, dLicenciaAnual)
        Dim sql As String = "DELETE FROM licenciaanual WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dLicenciaAnual
        Dim obj As dLicenciaAnual = CType(o, dLicenciaAnual)
        Dim l As New dLicenciaAnual
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, funcionario, dias, ano FROM licenciaanual WHERE id = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                l.ID = CType(unaFila.Item(0), Long)
                l.FUNCIONARIO = CType(unaFila.Item(1), Integer)
                l.DIAS = CType(unaFila.Item(2), Integer)
                l.ANO = CType(unaFila.Item(3), Integer)
                Return l
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscarxanoxusuario(ByVal o As Object) As dLicenciaAnual
        Dim obj As dLicenciaAnual = CType(o, dLicenciaAnual)
        Dim l As New dLicenciaAnual
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, funcionario, dias, ano FROM licenciaanual WHERE ano = " & obj.ANO & " AND funcionario = " & obj.FUNCIONARIO & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                l.ID = CType(unaFila.Item(0), Long)
                l.FUNCIONARIO = CType(unaFila.Item(1), Integer)
                l.DIAS = CType(unaFila.Item(2), Integer)
                l.ANO = CType(unaFila.Item(3), Integer)
                Return l
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, funcionario, dias, ano FROM licenciaanual ORDER BY ano DESC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dLicenciaAnual
                    l.ID = CType(unaFila.Item(0), Long)
                    l.FUNCIONARIO = CType(unaFila.Item(1), Integer)
                    l.DIAS = CType(unaFila.Item(2), Integer)
                    l.ANO = CType(unaFila.Item(3), Integer)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxano(ByVal ano As Integer) As ArrayList
        Dim sql As String = "SELECT id, funcionario, dias, ano FROM licenciaanual WHERE year(desde) = " & ano & " AND year(hasta) = " & ano & " ORDER BY desde ASC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dLicenciaAnual
                    l.ID = CType(unaFila.Item(0), Long)
                    l.FUNCIONARIO = CType(unaFila.Item(1), Integer)
                    l.DIAS = CType(unaFila.Item(2), Integer)
                    l.ANO = CType(unaFila.Item(3), Integer)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxusuario(ByVal idusuario As Integer, ByVal ano As Integer) As ArrayList
        Dim sql As String = "SELECT id, funcionario, dias, ano FROM licenciaanual WHERE idusuario= " & idusuario & " AND year(desde) = " & ano & " AND year(hasta) = " & ano & " ORDER BY desde ASC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dLicenciaAnual
                    l.ID = CType(unaFila.Item(0), Long)
                    l.FUNCIONARIO = CType(unaFila.Item(1), Integer)
                    l.DIAS = CType(unaFila.Item(2), Integer)
                    l.ANO = CType(unaFila.Item(3), Integer)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
