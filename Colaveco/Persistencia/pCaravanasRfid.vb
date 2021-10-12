Public Class pCaravanasRfid
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object) As Boolean
        Dim obj As dCaravanasRfid = CType(o, dCaravanasRfid)
        Dim sql As String = "INSERT INTO caravanas_rfid (id, equipo, fecha, productor, ficha, frasco, caravana, litros, excel, marca) VALUES (" & obj.ID & ", '" & obj.EQUIPO & "', '" & obj.FECHA & "'," & obj.PRODUCTOR & "," & obj.FICHA & ", '" & obj.FRASCO & "', '" & obj.CARAVANA & "'," & obj.LITROS & "," & obj.EXCEL & "," & obj.MARCA & ")"

        Dim lista As New ArrayList
        lista.Add(sql)



        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object) As Boolean
        Dim obj As dCaravanasRfid = CType(o, dCaravanasRfid)
        Dim sql As String = "UPDATE caravanas_rfid SET equipo = '" & obj.EQUIPO & "',fecha = '" & obj.FECHA & "', productor= " & obj.PRODUCTOR & ", ficha= " & obj.FICHA & ", frasco = '" & obj.FRASCO & "', caravana = '" & obj.CARAVANA & "', litros= " & obj.LITROS & ", marca= " & obj.EXCEL & ", marca= " & obj.MARCA & " WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)



        Return EjecutarTransaccion(lista)
    End Function
    Public Function asociarficha(ByVal o As Object, ByVal idsol As Long) As Boolean
        Dim obj As dCaravanasRfid = CType(o, dCaravanasRfid)
        Dim sql As String = "UPDATE caravanas_rfid SET ficha = " & idsol & " WHERE fecha = '" & obj.FECHA & "'"

        Dim lista As New ArrayList
        lista.Add(sql)



        Return EjecutarTransaccion(lista)
    End Function
    Public Function marcarexcel(ByVal o As Object) As Boolean
        Dim obj As dCaravanasRfid = CType(o, dCaravanasRfid)
        Dim sql As String = "UPDATE caravanas_rfid SET excel= 1 WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)



        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object) As Boolean
        Dim obj As dCaravanasRfid = CType(o, dCaravanasRfid)
        Dim sql As String = "DELETE FROM caravanas_rfid WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)



        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminartodo(ByVal o As Object) As Boolean
        Dim obj As dCaravanasRfid = CType(o, dCaravanasRfid)
        Dim sql As String = "DELETE FROM caravanas_rfid"

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dCaravanasRfid
        Dim obj As dCaravanasRfid = CType(o, dCaravanasRfid)
        Dim l As New dCaravanasRfid
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, equipo, fecha, productor, ficha, frasco, caravana, litros, excel, marca FROM caravanas_rfid WHERE id = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                l.ID = CType(unaFila.Item(0), Long)
                l.EQUIPO = CType(unaFila.Item(1), String)
                l.FECHA = CType(unaFila.Item(2), String)
                l.PRODUCTOR = CType(unaFila.Item(3), Long)
                l.FICHA = CType(unaFila.Item(4), Long)
                l.FRASCO = CType(unaFila.Item(5), String)
                l.CARAVANA = CType(unaFila.Item(6), String)
                l.LITROS = CType(unaFila.Item(7), Double)
                l.EXCEL = CType(unaFila.Item(8), Integer)
                l.MARCA = CType(unaFila.Item(9), Integer)
                Return l
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar(ByVal ideq As String, ByVal idpro As Long) As ArrayList
        Dim sql As String = "SELECT id, equipo, fecha, productor, ficha, frasco, caravana, litros, excel, marca FROM caravanas_rfid WHERE equipo = '" & ideq & "' AND productor = " & idpro & " AND excel = 0"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dCaravanasRfid
                    l.ID = CType(unaFila.Item(0), Long)
                    l.EQUIPO = CType(unaFila.Item(1), String)
                    l.FECHA = CType(unaFila.Item(2), String)
                    l.PRODUCTOR = CType(unaFila.Item(3), Long)
                    l.FICHA = CType(unaFila.Item(4), Long)
                    l.FRASCO = CType(unaFila.Item(5), String)
                    l.CARAVANA = CType(unaFila.Item(6), String)
                    l.LITROS = CType(unaFila.Item(7), Double)
                    l.EXCEL = CType(unaFila.Item(8), Integer)
                    l.MARCA = CType(unaFila.Item(9), Integer)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxproductor(ByVal idpro As Long) As ArrayList
        'Dim sql As String = "SELECT id, equipo, fecha, productor, ficha, frasco, caravana, litros, excel, marca FROM caravanas_rfid WHERE productor = " & idpro & " AND ficha = 0"
        Dim sql As String = "SELECT DISTINCT fecha FROM caravanas_rfid WHERE productor = " & idpro & " AND ficha = 0"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(Sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dCaravanasRfid
                    l.FECHA = CType(unaFila.Item(0), String)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
