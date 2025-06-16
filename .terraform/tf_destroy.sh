# cd ./4.\ Deploy/Admin_Dashboard
# echo ">>>>> Destroy Dashboard..."
# ./tf.sh destroy -auto-approve

cd ./4.\ Deploy/APIs
echo ">>>>> Destroy APIs..."
./tf.sh destroy -auto-approve

cd ../../3.\ SQL_Server/
echo ">>>>> Destroy SQL Server..."
./tf.sh destroy -auto-approve

cd ../2.\ Network/
echo ">>>>> Destroy Network..."
./tf.sh destroy -auto-approve

cd ../1.\ Main/
echo ">>>>> Destroy Main Reasources..."
./tf.sh destroy -auto-approve